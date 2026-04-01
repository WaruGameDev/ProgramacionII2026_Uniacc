using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public Transform visual;
    public MovementCharacter movementCharacter;


   
    void Update()
    {
        float horizontal = rb.linearVelocity.x;
        float vertical = rb.linearVelocity.y;
        if(horizontal > 0)
        {
            visual.localScale = new Vector3(1, 1, 1);
        }
        else if(horizontal < 0)
        {
            visual.localScale = new Vector3(-1, 1, 1);
        }

        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        animator.SetFloat("Vertical", vertical);      
        animator.SetBool("Grounded", movementCharacter.IsGrounded());
    }
}
