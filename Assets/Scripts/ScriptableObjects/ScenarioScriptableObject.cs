using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scenario", menuName = "Scenario", order = 1)]
public class ScenarioScriptableObject : ScriptableObject
{
    [SerializeField] private int level;
    [TextArea(8, 6)]
    [SerializeField] private string tutorialText;
    [SerializeField] private Scenario[] story;

    public string TutorialText => tutorialText;

    public Scenario[] Story => story;

    public int Level
    {
        get { return level; }
        set { level = value; }
    }
}