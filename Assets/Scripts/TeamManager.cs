using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : Listener
{
    public TeamScriptableObject Team;
    public ScenarioScriptableObject Scenario;
    private List<UnitScriptableObject> CurrentEnemyTeam = new List<UnitScriptableObject>();
    public Transform PositionParent;
    public GameObject UnitPrefab;

    private bool enemyCommanderUsed;
    // Start is called before the first frame update
    void SpawnTeam()
    {
        List<Unit> playerUnits = new List<Unit>();
        List<Unit> enemyUnits = new List<Unit>();
        if (!Team.tutorialComplete) Team.Reset();
        Team.tutorialComplete = true;
        int i = 0;
        for (i = 0; i < Team.activeUnits.Count; i++)
        {
            if(i == 3) break;
            playerUnits.Add(SpawnUnit(PositionParent.GetChild(i).position, Team.activeUnits[i]));
        }
        for (int j = i; j < 3; j++)
        {
            playerUnits.Add(null);
        }

        for (i = 0; i < CurrentEnemyTeam.Count; i++)
        {
            enemyUnits.Add(SpawnUnit(PositionParent.GetChild(i+3).position, CurrentEnemyTeam[i]));
        }
        for (int j = i; j < 3; j++)
        {
            enemyUnits.Add(null);
        }
        GameEvents.SetupUnits(playerUnits, enemyUnits);
    }

    Unit SpawnUnit(Vector3 spawnPos, UnitScriptableObject teamUnit)
    {
        Unit newUnit = Instantiate(UnitPrefab, spawnPos, Quaternion.identity).GetComponent<Unit>();
        newUnit.SetupUnit(teamUnit.UnitType, teamUnit.UnitName, teamUnit.VanguardAbilities, teamUnit.SupportAbilities, teamUnit.MaxHealth, teamUnit.MaxAmmo, teamUnit.MaxMana, teamUnit.Animator, teamUnit.Sprite);
            newUnit.gameObject.name =  teamUnit.UnitName;
            return newUnit;
    }

    void SetEnemyTeam()
    {
        Debug.Log(Scenario.story[Scenario.level+1].Enemies.Length);
        int randomPuzzle = Random.Range(0,Scenario.story[Scenario.level+1].Enemies.Length-1);
        CurrentEnemyTeam.Add(Scenario.story[Scenario.level+1].Enemies[randomPuzzle+1].enemies[0]);
        CurrentEnemyTeam.Add(Scenario.story[Scenario.level+1].Enemies[randomPuzzle+1].enemies[1]);
        CurrentEnemyTeam.Add(Scenario.story[Scenario.level+1].Enemies[randomPuzzle+1].enemies[2]);
        //CurrentEnemyTeam.Add(EnemyTeam[1]);
    }

    // Update is called once per frame
    private void Start()
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
