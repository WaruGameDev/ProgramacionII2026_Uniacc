using UnityEngine;

public class Unit : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float attackDamage = 10f;
    public float defense = 5f;
    public float speed = 1f;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void Attack(Unit target)
    {
        target.TakeDamage(attackDamage);
    }
    public void TakeDamage(float damage)
    {
        float effectiveDamage = Mathf.Max(damage - defense, 0);
        currentHealth -= effectiveDamage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        // Handle unit death (e.g., play animation, remove from game)
        Destroy(gameObject);
    }
}
