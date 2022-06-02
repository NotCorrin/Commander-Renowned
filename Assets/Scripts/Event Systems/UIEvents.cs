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
 * onUnitSelected(Unit)
 * menuClicked()
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

    public static Action<Unit, int, int> onUnitAmmoChanged;
    public static void UnitAmmoChanged(Unit unit, int newAmmo, int maxAmmo)
    {
        if (onUnitAmmoChanged != null)
        {
            onUnitAmmoChanged(unit, newAmmo, maxAmmo);
        }
    }

    public static Action<Unit, int, int> onUnitManaChanged;
    public static void UnitManaChanged(Unit unit, int newMana, int maxMana)
    {
        if (onUnitManaChanged != null)
        {
            onUnitManaChanged(unit, newMana, maxMana);
        }
    }

    public static Action<Unit, int> onUnitThornsChanged;
    public static void UnitThornsChanged(Unit unit, int newThorns)
    {
        if (onUnitThornsChanged != null)
        {
            onUnitThornsChanged(unit, newThorns);
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

    public static Action<GameManager.QTEDisplayResult> onDisplayQTEResults;
    public static void DisplayQTEResults(GameManager.QTEDisplayResult DisplayResult)
    {
        if (onDisplayQTEResults != null)
        {
            onDisplayQTEResults(DisplayResult);
        }
    }

    public static Action<Unit> onUnitSelected;
    public static void UnitSelected(Unit unit)
    {
        if (onUnitSelected != null)
        {
            onUnitSelected(unit);
        }
    }

    public static Action onMenuClicked;
    public static void OnMenuClicked()
    {
        if (onMenuClicked != null)
        {
            onMenuClicked();
        }
    }

    public static Action<bool> onAllSupportUsed;
    public static void AllSupportUsed(bool supportUsed)
    {
        if (onAllSupportUsed != null)
        {
            onAllSupportUsed(supportUsed);
        }
    }
}
