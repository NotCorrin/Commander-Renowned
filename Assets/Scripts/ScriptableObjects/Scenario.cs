using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Scenario
{
    [SerializeField] private string title;
    [TextArea(8, 6)]
    [SerializeField] private string description;
    [SerializeField] private SceneIndex scene;
    [SerializeField] private EnemyList[] enemies;

    [TextArea(8, 6)]
    [SerializeField] private string windescription;
    [SerializeField] private UnitScriptableObject[] winunit;

    public string Title => title;

    public string Description => description;

    public SceneIndex Scene => scene;

    public string Windescription => windescription;

    public UnitScriptableObject[] Winunit => winunit;

    public UnitScriptableObject[] GetEnemies(int i) => enemies[i].Enemies;

    public int GetNumPuzzles() => enemies.Length;
}