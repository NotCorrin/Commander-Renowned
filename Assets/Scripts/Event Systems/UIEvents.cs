using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1401 // Fields should be private

public static class UIEvents
{
    public static Action<Unit, int> onUnitHealthChanged;

    public static void UnitHealthChanged(Unit unit, int newHealth)
    {
        onUnitHealthChanged?.Invoke(unit, newHealth);
    }

    public static Action<Unit, int, int> onUnitAmmoChanged;

    public static void UnitAmmoChanged(Unit unit, int newAmmo, int maxAmmo)
    {
        onUnitAmmoChanged?.Invoke(unit, newAmmo, maxAmmo);
    }

    public static Action<Unit, int, int> onUnitManaChanged;

    public static void UnitManaChanged(Unit unit, int newMana, int maxMana)
    {
        onUnitManaChanged?.Invoke(unit, newMana, maxMana);
    }

    public static Action<Unit, int> onUnitThornsChanged;

    public static void UnitThornsChanged(Unit unit, int newThorns)
    {
        onUnitThornsChanged?.Invoke(unit, newThorns);
    }

    public static Action<Unit, int> onUnitAttackChanged;

    public static void UnitAttackChanged(Unit unit, int attackChange)
    {
        onUnitAttackChanged?.Invoke(unit, attackChange);
    }

    public static Action<Unit, int> onUnitPermAttackChanged;

    public static void UnitPermAttackChanged(Unit unit, int attackChange)
    {
        onUnitPermAttackChanged?.Invoke(unit, attackChange);
    }

    public static Action<Unit, int> onUnitDefenseChanged;

    public static void UnitDefenseChanged(Unit unit, int defenseChange)
    {
        onUnitDefenseChanged?.Invoke(unit, defenseChange);
    }

    public static Action<Unit, int> onUnitPermDefenseChanged;

    public static void UnitPermDefenseChanged(Unit unit, int defenseChange)
    {
        onUnitPermDefenseChanged?.Invoke(unit, defenseChange);
    }

    public static Action<Unit, int> onUnitAccuracyChanged;

    public static void UnitAccuracyChanged(Unit unit, int accuracyChange)
    {
        onUnitAccuracyChanged?.Invoke(unit, accuracyChange);
    }

    public static Action<GameManager.QTEDisplayResult> onDisplayQTEResults;

    public static void DisplayQTEResults(GameManager.QTEDisplayResult displayResult)
    {
        onDisplayQTEResults?.Invoke(displayResult);
    }

    public static Action<Unit> onUnitSelected;

    public static void UnitSelected(Unit unit)
    {
        onUnitSelected?.Invoke(unit);
    }

    public static Action onMenuClicked;

    public static void OnMenuClicked()
    {
        onMenuClicked?.Invoke();
    }

    public static Action<bool> onAllSupportUsed;

    public static void AllSupportUsed(bool supportUsed)
    {
        onAllSupportUsed?.Invoke(supportUsed);
    }
}

#pragma warning restore SA1201 // Elements should appear in the correct order
#pragma warning restore SA1401 // Fields should be private