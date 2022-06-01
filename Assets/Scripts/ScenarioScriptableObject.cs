using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scenario", menuName = "Scenario", order = 1)]
public class ScenarioScriptableObject : ScriptableObject
{
    public int level;
    [TextArea(8, 6)]
    public string tutorialText;
    public Scenario[] story;
}

[System.Serializable]
public class Scenario
{
    public string title;
    [TextArea(8,6)]
    public string description;
    public Enemies[] Enemies;
    [TextArea(8,6)]
    public string windescription;
    public UnitScriptableObject[] winunit;
}

[System.Serializable]
public class Enemies
{
    public UnitScriptableObject[] enemies;
}