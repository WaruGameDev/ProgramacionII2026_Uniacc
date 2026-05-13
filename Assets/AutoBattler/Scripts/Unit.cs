using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class Unit : MonoBehaviour
{
    public UnitType unitType;
   
    public float maxHealth = 100f;
    public float currentHealth;
    public float attackDamage = 10f;
    public float defense = 5f;
    public float speed = 1f;
    public Transform frontPoint;
    Tween damageTween;
    public Image healthBarFill;
    public UnitData data;
    public SpriteRenderer spriteRenderer;

    public void Initialize(UnitData unitData)
    {
        data = unitData;
        maxHealth = unitData.maxHealth;
        attackDamage = unitData.attackDamage;
        defense = unitData.defense;
        speed = unitData.speed;
        spriteRenderer.sprite = unitData.unitSprite;
        unitType = unitData.unitType;
        if(!data.isPlayerUnit)     
        {
            // Set enemy unit specific properties (e.g., color, layer)
            spriteRenderer.transform.localScale = new Vector3(-1, 1, 1); // Flip sprite for enemy
        }
    }

    void Start()
    {
        Initialize(data);
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
        float effectiveDamage;
        GameObject damageTextObj = Instantiate(BattleManager.Instance.damageTextPrefab, 
            transform.position + new Vector3(0,2,0), Quaternion.identity);
        TextMeshPro damageText = damageTextObj.GetComponent<TextMeshPro>();
        damageTextObj.transform.DOJump(damageTextObj.transform.position, 1f, 1, 0.5f).
            SetEase(Ease.OutQuad).OnComplete(() =>
        {
            Destroy(damageTextObj);
        });
        if(damage >= 0)
        {
            effectiveDamage = Mathf.Max(damage - defense, 0);           
            damageText.text = effectiveDamage.ToString("0");
            damageText.color = Color.red;
        }
        else
        {
            effectiveDamage = damage; // Healing is not reduced by defense
            damageText.text = effectiveDamage.ToString("0");
            damageText.color = Color.green;
        }

        
        healthBarFill.fillAmount = (currentHealth - effectiveDamage) / maxHealth;        
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
