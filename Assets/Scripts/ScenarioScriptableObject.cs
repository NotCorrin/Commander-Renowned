using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scenario", menuName = "Scenario", order = 1)]
public class ScenarioScriptableObject : ScriptableObject
{
    public Scenario[] story;
}

[System.Serializable]
public class Scenario
{
    [TextArea(15,20)]
    public string scenario;
    public List<UnitScriptableObject> enemies;
}