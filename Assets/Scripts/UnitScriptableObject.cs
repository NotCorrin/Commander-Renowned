using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit", order = 1)]
public class UnitScriptableObject : ScriptableObject
{
    public UnitType unitType;
    public string UnitName;

    public Type T;
    public AbilitySetup[] VanguardAbilities;
    public AbilitySetup[] SupportAbilities;
    //public List<AbilitySetup> VanguardAbilities2; For use when adding abilities

    public int MaxHealth;
    public int MaxAmmo;
    public int MaxMana;
    public RuntimeAnimatorController animator;
    public Sprite sprite;
}
