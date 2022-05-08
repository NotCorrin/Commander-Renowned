using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommanderUnit : Unit
{
    [SerializeField] private int maxAmmo;
    public int MaxAmmo
    {
        get => maxAmmo;
    }

    private int ammo;
    public int Ammo
    {
        get => ammo;
        set
        {
            ammo = Mathf.Min(Mathf.Max(value, 0), MaxAmmo);
            UIEvents.UnitAmmoChanged(this, ammo, maxAmmo);
        }
    }

    [SerializeField] private int maxMana;
    public int MaxMana
    {
        get => maxMana;
    }

    private int mana;
    public int Mana
    {
        get => mana;
        set
        {
            mana = Mathf.Min(Mathf.Max(value, 0), MaxMana);
            UIEvents.UnitManaChanged(this, mana);
        }
    }

    protected override void ResetUnit()
    {
        Mana = MaxMana / 2;
        Ammo = MaxAmmo;
        base.ResetUnit();
    }

    protected override void SubscribeListeners()
    {
        GameEvents.onUseMana += OnUseMana;
        GameEvents.onUseAmmo += OnUseAmmo;
        base.SubscribeListeners();
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onUseMana -= OnUseMana;
        GameEvents.onUseAmmo -= OnUseAmmo;
        base.UnsubscribeListeners();
    }

    private void OnUseAmmo(Unit caster, int cost)
    {
        if (caster == this)
        {
            Ammo -= cost;
        }
    }

    private void OnUseMana(Unit caster, int cost)
    {
        if (caster == this)
        {
            Mana -= cost;
        }
    }
}
