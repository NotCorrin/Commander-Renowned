using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : Listener
{
    public TeamScriptableObject Team;
    public List<UnitScriptableObject> EnemyTeam;
    private List<UnitScriptableObject> CurrentEnemyTeam = new List<UnitScriptableObject>();
    public Transform PositionParent;
    public GameObject UnitPrefab;

    // Start is called before the first frame update
    void SpawnTeam()
    {
        List<Unit> playerUnits = new List<Unit>();
        List<Unit> enemyUnits = new List<Unit>();
        int i = 0;
        for (i = 0; i < Team.units.Count; i++)
        {
            Unit newUnit = Instantiate(UnitPrefab, PositionParent.GetChild(i).position, Quaternion.identity).GetComponent<Unit>();
            newUnit.gameObject.name = newUnit.UnitName;
            playerUnits.Add(newUnit);
            UnitScriptableObject unitParams = Team.units[i];
            newUnit.SetupUnit(unitParams.unitType, unitParams.UnitName, unitParams.VanguardAbilities, unitParams.SupportAbilities, unitParams.MaxHealth, unitParams.MaxAmmo, unitParams.MaxMana, unitParams.animator);
        }
        for (int j = i; j < 3; j++)
        {
            playerUnits.Add(null);
        }

        for (i = 0; i < EnemyTeam.Count; i++)
        {
            Unit newUnit = Instantiate(UnitPrefab, PositionParent.GetChild(i+3).position, Quaternion.identity).GetComponent<Unit>();
            newUnit.gameObject.name = newUnit.UnitName;
            enemyUnits.Add(newUnit);
            UnitScriptableObject unitParams = EnemyTeam[i];
            newUnit.SetupUnit(unitParams.unitType, unitParams.UnitName, unitParams.VanguardAbilities, unitParams.SupportAbilities, unitParams.MaxHealth, unitParams.MaxAmmo, unitParams.MaxMana, unitParams.animator);
        }
        for (int j = i; j < 3; j++)
        {
            enemyUnits.Add(null);
        }
        GameEvents.SetupUnits(playerUnits, enemyUnits);
    }    
    // Start is called before the first frame update
    void SetEnemyTeam()
    {
        CurrentEnemyTeam.Add(EnemyTeam[0]);
        CurrentEnemyTeam.Add(EnemyTeam[1]);
    }

    // Update is called once per frame
    void Start()
    {
        SetEnemyTeam();
        SpawnTeam();
    }
    protected override void SubscribeListeners()
    {

    }
    protected override void UnsubscribeListeners()
    {

    }
}
