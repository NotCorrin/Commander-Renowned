using System;
using System.Collections.Generic;
using UnityEngine;

#pragma 
/*
 * Event list:
 * onBattleStart()
 * onHealthChanged(Unit, int)
 * onDefenseUp(Unit, int)
 * onAttackUp(Unit, int)
 * onAccuracyUp(Unit, int)
 * onUseAmmo(Unit, int)
 * onUseMana(Unit, int)
 * onUseAbility(Unit, Unit, int)
 * onQTEStart(GameManager.QTEType)
 * onQTEResolves(GameManager.QTEResult)
 */

#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1401 // Fields should be private

public static class GameEvents
{
    // Start is called before the first frame update

    /// <summary> 
    /// Called when a battle is started.
    /// </summary>
    public static Action onBattleStarted;

    public static void BattleStart()
    {
        onBattleStarted?.Invoke();
    }

    /// <summary>
    /// Called with lists of units to spawn when units are being set up.
    /// </summary>
    private static Action<List<Unit>, List<Unit>> onSetupUnits;

    public static void SetupUnits(List<Unit> playerUnits, List<Unit> enemyUnits)
    {
        if (onSetupUnits != null)
        {
            onSetupUnits?.Invoke(playerUnits, enemyUnits);
        }
    }

    private static Action<Unit, int> onHealthChanged;

    public static void HealthChanged(Unit target, int value)
    {
        if (onHealthChanged != null)
        {
            onHealthChanged?.Invoke(target, value);
        }
    }

    public static Action<Unit, Unit, int> onUnitAttack;

    public static void UnitAttack(Unit attacker, Unit defender, int value)
    {
        HealthChanged(defender, value);
        if (onUnitAttack != null)
        {
            onUnitAttack?.Invoke(attacker, defender, value);
        }
    }

    public static Action<Unit, int> onDefenseUp;

    public static void DefenseUp(Unit caster, int amount)
    {
        if (onDefenseUp != null)
        {
            onDefenseUp?.Invoke(caster, amount);
        }
    }

    public static Action<Unit, int> onBaseDefenseUp;

    public static void BaseDefenseUp(Unit caster, int amount)
    {
        if (onBaseDefenseUp != null)
        {
            onBaseDefenseUp?.Invoke(caster, amount);
        }
    }

    public static Action<Unit, int> onAttackUp;

    public static void AttackUp(Unit caster, int amount)
    {
        if (onAttackUp != null)
        {
            onAttackUp?.Invoke(caster, amount);
        }
    }

    public static Action<Unit, int> onBaseAttackUp;

    public static void BaseAttackUp(Unit caster, int amount)
    {
        if (onBaseAttackUp != null)
        {
            onBaseAttackUp?.Invoke(caster, amount);
        }
    }

    public static Action<Unit, int> onAccuracyUp;

    public static void AccuracyUp(Unit caster, int amount)
    {
        if (onAccuracyUp != null)
        {
            onAccuracyUp?.Invoke(caster, amount);
        }
    }

    public static Action<Unit, int> onThornsUp;

    public static void ThornsUp(Unit caster, int Amount)
    {
        if (onThornsUp != null)
        {
            onThornsUp?.Invoke(caster, Amount);
        }
    }

    public static Action<Unit, int> onUseAmmo;
    public static void UseAmmo(Unit Caster, int Cost)
    {
        if (onUseAmmo != null)
        {
            onUseAmmo?.Invoke(Caster, Cost);
        }
    }

    public static Action<Unit, int> onUseMana;
    public static void UseMana(Unit Caster, int Cost)
    {
        if (onUseMana != null)
        {
            onUseMana?.Invoke(Caster, Cost);
        }
    }

    public static Action<Ability, bool> onGreyOut;
    public static void GreyOut(Ability ability, bool disable)
    {
        if (onGreyOut != null)
        {
            onGreyOut?.Invoke(ability, disable);
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
            onUseAbility?.Invoke(caster, target, abilityNumber);
        }
    }

    public static Action<GameManager.QTEType, int> onQTEStart;
    public static void QTEStart(GameManager.QTEType qteType, int difficultyModifier)
    {
        if (onQTEStart != null)
        {
            onQTEStart?.Invoke(qteType, difficultyModifier);
        }
    }

    public static Action<GameManager.QTEResult> onQTEResolved;
    public static void QTEResolved(GameManager.QTEResult QTEResult)
    {
        if (onQTEResolved != null)
        {
            onQTEResolved?.Invoke(QTEResult);
        }
    }

    public static Action<Unit> onSwitchUnitEnd;
    public static void SwitchUnitEnd(Unit unitSwitched)
    {
        if (onSwitchUnitEnd != null)
        {
            onSwitchUnitEnd?.Invoke(unitSwitched);
        }
    }

    public static Action<Unit> onAbilityResolved;
    public static void AbilityResolved(Unit source)
    {
        if (onAbilityResolved != null)
        {
            onAbilityResolved?.Invoke(source);
        }
    }

    public static Action<Unit> onKill;
    public static void Kill(Unit source)
    {
        if (onKill != null)
        {
            onKill?.Invoke(source);
        }
    }

    public static Action<bool> onGameEnd;
    public static void GameEnd(bool win)
    {
        if (onGameEnd != null)
        {
            onGameEnd?.Invoke(win);
        }
    }

    // public static Action<Unit> onUnitClick;
    public static Action roundcontrollerEndPhase;
    public static void EndPhase()
    {
        roundcontrollerEndPhase?.Invoke();
    }

    public static Action onResetBuffs;
    public static void ResetBuffs()
    {
        onResetBuffs?.Invoke();
    }

    // public static Action<RoundController.Phase> onSetPhase;
    public static Action<RoundController.Phase> onPhaseChanged;


    public static Action<List<Unit>, List<Unit>> OnSetupUnits { get => onSetupUnits; set => onSetupUnits = value; }

    public static void PhaseChanged(RoundController.Phase phase)
    {
        onPhaseChanged?.Invoke(phase);
    }
}

#pragma warning restore SA1201 // Elements should appear in the correct order
#pragma warning restore SA1401 // Fields should be private
