using System.Collections.Generic;
using UnityEngine;


public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

    public List<Unit> playerUnits = new List<Unit>();
    public List<Unit> enemyUnits = new List<Unit>();
    public List<Unit> turnOrder = new List<Unit>();
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }        
    }
    private void SortTurnOrder()
    {
        turnOrder.Clear();
        turnOrder.AddRange(playerUnits);
        turnOrder.AddRange(enemyUnits);
        turnOrder.Sort((a, b) => b.speed.CompareTo(a.speed));
    }
    void Start()
    {
        StartBattle();
    }
    public void StartBattle()
    {
        SortTurnOrder();
        BattleLoop();
    }    

    public void BattleLoop()
    {
        if(playerUnits.Count > 0 && enemyUnits.Count > 0 )
        {
            if(turnOrder.Count > 0)
            {
                ProcessTurn();
            }
            else
            {
                StartBattle();
            }
           
            
        }
    }
    void ProcessTurn()
    {
            Unit currentUnit = turnOrder[0];
            if (playerUnits.Contains(currentUnit))
            {
                // Player unit's turn
                Unit target = enemyUnits[Random.Range(0, enemyUnits.Count)];
                currentUnit.Attack(target, () =>
                {
                    if (target.currentHealth <= 0)
                    {
                        enemyUnits.Remove(target);
                        turnOrder.Remove(target);
                    }
                    turnOrder.RemoveAt(0);
                    BattleLoop();
                });
            }
            else
            {
                // Enemy unit's turn
                Unit target = playerUnits[Random.Range(0, playerUnits.Count)];
                currentUnit.Attack(target, () =>
                {
                    if (target.currentHealth <= 0)
                    {
                        playerUnits.Remove(target);
                        turnOrder.Remove(target);
                    }
                    turnOrder.RemoveAt(0);
                    BattleLoop();
                });
            }}
   
}
