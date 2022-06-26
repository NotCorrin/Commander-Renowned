using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : Listener
{
    [SerializeField] private TeamScriptableObject team;
    [SerializeField] private ScenarioScriptableObject scenario;
    private List<UnitScriptableObject> currentEnemyTeam;
    [SerializeField] private Transform positionParent;
    [SerializeField] private GameObject unitPrefab;

    protected override void SubscribeListeners()
    {
    }

    protected override void UnsubscribeListeners()
    {
    }

    private void Start()
    {
        SetEnemyTeam();
        SpawnTeam();
    }

    private void SpawnTeam()
    {
        List<Unit> playerUnits = new List<Unit>();
        List<Unit> enemyUnits = new List<Unit>();
        if (!team.TutorialComplete)
        {
            team.Reset();
        }

        team.TutorialComplete = true;

        int i;
        for (i = 0; i < team.ActiveUnits.Count; i++)
        {
            if (i == 3)
            {
                break;
            }

            playerUnits.Add(SpawnUnit(positionParent.GetChild(i).position, team.ActiveUnits[i]));
        }

        for (int j = i; j < 3; j++)
        {
            playerUnits.Add(null);
        }

        for (i = 0; i < currentEnemyTeam.Count; i++)
        {
            enemyUnits.Add(SpawnUnit(positionParent.GetChild(i + 3).position, currentEnemyTeam[i]));
        }

        for (int j = i; j < 3; j++)
        {
            enemyUnits.Add(null);
        }

        GameEvents.SetupUnits(playerUnits, enemyUnits);
    }

    private Unit SpawnUnit(Vector3 spawnPos, UnitScriptableObject teamUnit)
    {
        Unit newUnit = Instantiate(unitPrefab, spawnPos, Quaternion.identity).GetComponent<Unit>();
        newUnit.SetupUnit(teamUnit.UnitType, teamUnit.UnitName, teamUnit.VanguardAbilities, teamUnit.SupportAbilities, teamUnit.MaxHealth, teamUnit.MaxAmmo, teamUnit.MaxMana, teamUnit.Animator, teamUnit.Sprite);
        newUnit.gameObject.name = teamUnit.UnitName;
        return newUnit;
    }

    private void SetEnemyTeam()
    {
        Debug.Log(scenario.story[scenario.level + 1].Enemies.Length);
        int randomPuzzle = Random.Range(0, scenario.story[scenario.level + 1].Enemies.Length - 1);
        currentEnemyTeam = new List<UnitScriptableObject>();
        currentEnemyTeam.Add(scenario.story[scenario.level + 1].Enemies[randomPuzzle + 1].enemies[0]);
        currentEnemyTeam.Add(scenario.story[scenario.level + 1].Enemies[randomPuzzle + 1].enemies[1]);
        currentEnemyTeam.Add(scenario.story[scenario.level + 1].Enemies[randomPuzzle + 1].enemies[2]);
    }
}
