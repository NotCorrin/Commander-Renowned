using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Team", menuName = "Team", order = 1)]
public class TeamScriptableObject : ScriptableObject
{
    public List<UnitScriptableObject> units;
}
