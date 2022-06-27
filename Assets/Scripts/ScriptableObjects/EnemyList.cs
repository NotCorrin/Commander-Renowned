using UnityEngine;

[System.Serializable]
public struct EnemyList
{
    [SerializeField] private UnitScriptableObject[] enemies;

    public UnitScriptableObject[] Enemies => enemies;
}