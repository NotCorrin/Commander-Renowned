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
        List<Unit> units = new List<Unit>();
        for (int i = 0; i < Team.units.Count; i++)
        {
            Unit newUnit = Instantiate(UnitPrefab, PositionParent.GetChild(i).position, Quaternion.identity).GetComponent<Unit>();
            units.Add(newUnit);
            UnitScriptableObject unitParams = Team.units[i];
            newUnit.SetupUnit(unitParams.unitType, unitParams.UnitName, unitParams.VanguardAbilities, unitParams.SupportAbilities, unitParams.MaxHealth, unitParams.MaxAmmo, unitParams.MaxMana, unitParams.animator);
        }

        for (int i = 0; i < EnemyTeam.Count; i++)
        {
            Unit newUnit = Instantiate(UnitPrefab, PositionParent.GetChild(i+3).position, Quaternion.identity).GetComponent<Unit>();
            units.Add(newUnit);
            UnitScriptableObject unitParams = Team.units[i];
            newUnit.SetupUnit(unitParams.unitType, unitParams.UnitName, unitParams.VanguardAbilities, unitParams.SupportAbilities, unitParams.MaxHealth, unitParams.MaxAmmo, unitParams.MaxMana, unitParams.animator);
        }
    }    
    // Start is called before the first frame update
    void SetEnemyTeam()
    {

        CurrentEnemyTeam.Add(EnemyTeam[0]);
        CurrentEnemyTeam.Add(EnemyTeam[1]);
    }

    // Update is called once per frame
    void Awake()
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
