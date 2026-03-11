using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.CollectCoin(value);
           
            Destroy(gameObject);
        }
    }
}
