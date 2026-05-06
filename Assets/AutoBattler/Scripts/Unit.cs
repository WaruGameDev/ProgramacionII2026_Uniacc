using UnityEngine;
using DG.Tweening;

public class Unit : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float attackDamage = 10f;
    public float defense = 5f;
    public float speed = 1f;
    public Transform frontPoint;
    Tween damageTween;

    void Start()
    {
        damageTween = transform.DOPunchScale(new Vector3(.2f,- .2f, .2f), 0.2f).SetAutoKill(false).Pause();
        currentHealth = maxHealth;
    }
    public void Attack(Unit target, System.Action onAttackComplete = null)
    {
        Vector3 originalPosition = transform.position;
        transform.DOJump(target.frontPoint.position, 1f, 1, 0.5f).SetEase(Ease.OutQuad).OnComplete(() =>
        {
             target.TakeDamage(attackDamage);
             transform.DOMove(originalPosition, 0.5f).SetEase(Ease.InQuad).OnComplete(() =>
             {
                 onAttackComplete?.Invoke();
             });
        });
       
    }
    public void TakeDamage(float damage)
    {
        float effectiveDamage = Mathf.Max(damage - defense, 0);
        
        currentHealth -= effectiveDamage;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            damageTween.Restart();
        }
    }
    void Die()
    {
        // Handle unit death (e.g., play animation, remove from game)
        Destroy(gameObject);
    }
}
