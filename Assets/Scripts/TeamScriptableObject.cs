using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Team", menuName = "Team", order = 1)]
public class TeamScriptableObject : ScriptableObject
{
    public TeamScriptableObject templateTeam;

    public bool tutorialComplete;
    public List<UnitScriptableObject> units;
    public List<UnitScriptableObject> activeUnits;

    public void Reset()
    {
        units.Clear();
        activeUnits.Clear();
        foreach (var item in templateTeam.units)
        {
            units.Add(item);
            if(units.Count<=3) activeUnits.Add(item);
        }
    }
}
