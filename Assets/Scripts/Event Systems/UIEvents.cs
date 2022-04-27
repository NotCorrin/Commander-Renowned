using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * Event list:
 * onUnitHealthChanged(Unit, int)
 * onUnitAmmoChanged(Unit, int)
 * onUnitManaChanged(Unit, int)
 * onUnitAttackChanged(Unit, int)
 * onUnitDefenseChanged(Unit, int)
 * onUnitAccuracyChanged(Unit, int)
 * onDisplayQTEResults(QTEController.QTEDisplayResult)
 */

public static class UIEvents
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

    public static Action<Unit, int> onUnitAttackChanged;
    public static void UnitAttackChanged(Unit unit, int attackChange)
    {
        if (onUnitAttackChanged != null)
        {
            onUnitAttackChanged(unit, attackChange);
        }
    }

    public static Action<Unit, int> onUnitDefenseChanged;
    public static void UnitDefenseChanged(Unit unit, int defenseChange)
    {
        if (onUnitDefenseChanged != null)
        {
            onUnitDefenseChanged(unit, defenseChange);
        }
    }

    public static Action<Unit, int> onUnitAccuracyChanged;
    public static void UnitAccuracyChanged(Unit unit, int AccuracyChange)
    {
        if (onUnitAccuracyChanged != null)
        {
            onUnitAccuracyChanged(unit, AccuracyChange);
        }
    }

    public static Action<QTEController.QTEDisplayResult> onDisplayQTEResults;
    public static void DisplayQTEResults(QTEController.QTEDisplayResult DisplayResult)
    {
        if (onDisplayQTEResults != null)
        {
            onDisplayQTEResults(DisplayResult);
        }
    }

    public static Action<Unit> onUnitSelected;
    public static void UnitSelected(Unit unit)
    {
        Debug.Log("Hmm");
        if (onUnitSelected != null)
        {
            onUnitSelected(unit);
        }
    }
}
