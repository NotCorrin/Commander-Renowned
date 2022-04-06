using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * Event list:
 * onUnitHealthChanged
 * onUnitAmmoChanged
 * onUnitManaChanged
 */

public static class ScoreEvents
{
    public static Action<Unit, int> onUnitHealthChanged;
    public static void UnitHealthChanged(Unit unit, int newHealth)
    {
        if (onUnitHealthChanged != null)
        {
            onUnitHealthChanged(unit, newHealth);
        }
    }

    public static Action<Unit, int> onUnitAmmoChanged;
    public static void UnitAmmoChanged(Unit unit, int newAmmo)
    {
        if (onUnitAmmoChanged != null)
        {
            onUnitAmmoChanged(unit, newAmmo);
        }
    }

    public static Action<Unit, int> onUnitManaChanged;
    public static void UnitManaChanged(Unit unit, int newMana)
    {
        if (onUnitManaChanged != null)
        {
            onUnitManaChanged(unit, newMana);
        }
    }
}
