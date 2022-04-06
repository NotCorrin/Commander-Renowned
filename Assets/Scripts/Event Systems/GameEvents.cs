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

    public static Action<Unit> onDefenceUp;
    public static void DefenceUp(Unit Caster)
    {
        if (onDefenceUp != null)
        {
            onDefenceUp(Caster);
        }
    }

    public static Action<Unit> onAttackUp;
    public static void AttackUp(Unit Caster)
    {
        if (onAttackUp != null)
        {
            onAttackUp(Caster);
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
}
