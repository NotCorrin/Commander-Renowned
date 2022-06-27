using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Team", menuName = "Team", order = 1)]
public class TeamScriptableObject : ScriptableObject
{
    [SerializeField] private TeamScriptableObject templateTeam;

    [SerializeField] private bool tutorialComplete;

    [SerializeField] private List<UnitScriptableObject> units;

    [SerializeField] private List<UnitScriptableObject> activeUnits;

    public bool TutorialComplete
    {
        get { return tutorialComplete; }
        set { tutorialComplete = value; }
    }

    public List<UnitScriptableObject> Units
    {
        get { return units; }
        set { units = value; }
    }

    public List<UnitScriptableObject> ActiveUnits
    {
        get { return activeUnits; }
        set { activeUnits = value; }
    }

    /// <summary>
    /// Reset team to templateTeam values; currently only used when restarting after finishing the game.
    /// </summary>
    public void Reset()
    {
        units.Clear();
        activeUnits.Clear();
        foreach (var item in templateTeam.units)
        {
            units.Add(item);
            if (units.Count <= 3)
            {
                activeUnits.Add(item);
            }
        }
    }
}
