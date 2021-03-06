using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilitySetup
{
    public AbilityScript AbilityType;
    public string AbilityName;
    [TextArea(5, 5)]
    public string AbilityDescription;
    public int Cost;
    public int Damage;
    public int StatBoost;
    public int Variation;
    public TargetMode ForceTarget = TargetMode.Default;

    public GameObject VFX1;
    public GameObject VFX2;
    public GameObject VFX3;
}

public enum AbilityScript
{
    MageAttack,
    MageBuff,
    MageDefend,
    Attack,
    Defend,
    SoldierAbility,
    MageFireball,
    Charge,
    Trace,
    EnergySword,
    PaladinBuff,
    DruidLeech,
    BrambleShield,
    MechAttack,
    OldAttack,
    TankAttack,
    CommanderBuff,
    CommanderReload
}