using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
 * onQTEStart(QTEController.QTEType)
 * onQTEResolves(QTEController.QTEResult)
 */

public static class GameEvents
{
    // Start is called before the first frame update
    public static Action onBattleStarted;
    public static void BattleStart()
    {
        SetPhase(RoundController.Phase.PlayerVanguard);
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

    public static Action<Unit, int> onDefenseUp;
    public static void DefenseUp(Unit Caster, int Amount)
    {
        if (onDefenseUp != null)
        {
            onDefenseUp(Caster, Amount);
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

    public static Action<Unit, int> onAccuracyUp;
    public static void AccuracyUp(Unit Caster, int Amount)
    {
        if (onAccuracyUp != null)
        {
            onAccuracyUp(Caster, Amount);
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

    public static Action<QTEController.QTEType, int> onQTEStart;
    public static void QTEStart( QTEController.QTEType qteType, int difficultyModifier)
    {
        if (onQTEStart != null)
        {
            onQTEStart(qteType, difficultyModifier);
        }
    }

    public static Action<QTEController.QTEResult> onQTEResolved;
    public static void QTEResolved(QTEController.QTEResult QTEResult)
    {
        if (onQTEResolved != null)
        {
                    Debug.Log("AAAAAAAAA2");

            onQTEResolved(QTEResult);
        }
    }
    
    public static Action<Unit> onSwitchUnitEnd;
    public static void SwitchUnitEnd(Unit unitSwitched)
    {
        if (onSwitchUnitEnd != null)
        {
            onSwitchUnitEnd(unitSwitched);
        }
    }

    public static Action<Unit> onAbilityResolved;
    public static void AbilityResolved(Unit source)
    {
        if (onAbilityResolved != null)
        {
            onAbilityResolved(source);
        }
    }

    // public static Action<RoundController.Phase> onSetPhase;
    public static Action<RoundController.Phase> onPhaseChanged;
    public static void SetPhase(RoundController.Phase phase = RoundController.Phase.NextPhase)
    {
        RoundController.SetPhase(phase);
        // Additional event not needed
        // if (onSetPhase != null)
        // {
        //     onSetPhase(phase);
        // }
        if (onPhaseChanged != null)
        {
            onPhaseChanged(RoundController.phase);
        }
    }    
    
    //public static Action<Unit> onUnitClick;
}
