using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int coinCount = 0;
    public TextMeshProUGUI coinText;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;           
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        coinText.text = "x" + coinCount;
    }
    public void CollectCoin(int amount)
    {
        coinCount += amount;
        coinText.text = "x" + coinCount;
        Debug.Log("Coins: " + coinCount);
    }
}
