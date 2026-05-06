using UnityEngine;


public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }
    public Unit playerUnit;
    public Unit enemyUnit;
    int turnCounter = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }        
    }
    void Start()
    {
        NextTurn();
    }

    public void NextTurn()
    {
        // Implement turn logic here (e.g., decide who attacks next)
        if(turnCounter % 2 == 0)
        {
            playerUnit.Attack(enemyUnit, NextTurn);
        }
        else
        {
            enemyUnit.Attack(playerUnit, NextTurn);
        }
        turnCounter++;

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerUnit.Attack(enemyUnit);
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            enemyUnit.Attack(playerUnit);
        }
    }
}
