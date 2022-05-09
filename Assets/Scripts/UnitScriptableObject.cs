using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit", order = 1)]
public class UnitScriptableObject : ScriptableObject
{
    public UnitType unitType;
    public string UnitName;

    public AbilitySetup[] VanguardAbilities;
    public AbilitySetup[] SupportAbilities;

    public int MaxHealth;
    public int MaxAmmo;
    public int MaxMana;
    public Animator animator;
}
