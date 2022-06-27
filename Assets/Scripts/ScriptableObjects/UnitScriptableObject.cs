using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores the unit values.
/// </summary>
[CreateAssetMenu(fileName = "New Unit", menuName = "Unit", order = 1)]
public class UnitScriptableObject : ScriptableObject
{
    [SerializeField] private UnitType unitType;

    [SerializeField] private string unitName;

    [SerializeField] private AbilitySetup[] vanguardAbilities;

    [SerializeField] private AbilitySetup[] supportAbilities;

    [SerializeField] private int maxHealth;

    [SerializeField] private int maxAmmo;

    [SerializeField] private int maxMana;

    [SerializeField] private RuntimeAnimatorController animator;

    [SerializeField] private Sprite sprite;

    public UnitType UnitType { get => unitType; }

    public string UnitName { get => unitName; }

    public AbilitySetup[] VanguardAbilities { get => vanguardAbilities; }

    public AbilitySetup[] SupportAbilities { get => supportAbilities; }

    public int MaxHealth { get => maxHealth; }

    public int MaxAmmo { get => maxAmmo; }

    public int MaxMana { get => maxMana; }

    public RuntimeAnimatorController Animator { get => animator; }

    public Sprite Sprite { get => sprite; }
}
