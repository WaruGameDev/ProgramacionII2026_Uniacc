using System.Collections.Generic;
using UnityEngine;

public class CombatEvent : DungeonEvent
{
    public List<UnitData> enemyUnitsData;

    public override void TriggerEvent()
    {    
        BattleManager.Instance.StartBattle(this);
    }
}
