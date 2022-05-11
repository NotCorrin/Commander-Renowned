using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommanderUnit : Unit
{
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
