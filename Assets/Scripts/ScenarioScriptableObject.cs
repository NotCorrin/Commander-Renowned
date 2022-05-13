using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scenario", menuName = "Scenario", order = 1)]
public class ScenarioScriptableObject : ScriptableObject
{
    public int level;
    public Scenario[] story;
}

[System.Serializable]
public class Scenario
{
    public string title;
    [TextArea(15,6)]
    public string description;
    public Enemies[] Enemies;
}

[System.Serializable]
public class Enemies
{
    public UnitScriptableObject[] enemies;
}