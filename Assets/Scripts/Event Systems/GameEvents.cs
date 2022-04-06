using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * Event list:
 * onBattleStart
 */

public static class GameEvents
{
    // Start is called before the first frame update
    public static Action onBattleStarted;
    public static void BattleStart()
    {
        if (onBattleStarted != null)
        {
            onBattleStarted();
        }
    }

    public static Action<Unit, int> onHealthChanged;
    public static void HealthChanged(Unit target, int Value)
    {
        if (onHealthChanged != null)
        {
            onHealthChanged(target, Value);
        }
    }

    public static Action<Unit, int> onDefenceUp;
    public static void DefenceUp(Unit Caster, int Amount)
    {
        if (onDefenceUp != null)
        {
            onDefenceUp(Caster, Amount);
        }
    }

    public static Action<Unit, int> onAttackUp;
    public static void AttackUp(Unit Caster, int Amount)
    {
        if (onAttackUp != null)
        {
            onAttackUp(Caster, Amount);
        }
    }

    public static Action<Unit, int> onUseAmmo;
    public static void UseAmmo(Unit Caster, int Cost)
    {
        if (onUseAmmo != null)
        {
            onUseAmmo(Caster, Cost);
        }
    }

    public static Action<Unit, int> onUseMana;
    public static void UseMana(Unit Caster, int Cost)
    {
        if (onUseMana != null)
        {
            onUseMana(Caster, Cost);
        }
    }

    public static Action<Unit, Unit, int> onUseAbility;
    public static void UseAbility(Unit caster, Unit target, int abilityNumber)
    {
        if (abilityNumber > 3 || abilityNumber < 1)
        {
            Debug.Log("Invalid Ability Number");
            return;
        }
             
        if (onUseAbility != null)
        {
            onUseAbility(caster, target, abilityNumber);
        }
    }
}
