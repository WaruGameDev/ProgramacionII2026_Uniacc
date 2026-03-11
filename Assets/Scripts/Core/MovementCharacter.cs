using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;    
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(xInput * speed, rb.linearVelocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 
        groundCheckRadius, LayerMask.GetMask("Ground"));
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
