using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : Listener
{
    public static RoundController main;
    public static Phase phase;
    private int numUnitsUsed;
    public Unit unitSwitched;
    public Unit unitUsed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void ChooseAttack()
    {
        phase = Phase.PlayerVanguard;
    }

    void SwapSupport(QTEController.QTEResult QTEResult)
    {
        GameEvents.SetPhase(Phase.NextPhase);
    }
    void SwapSupport(Unit unit)
    {
        GameEvents.SetPhase(Phase.NextPhase);
    }

    public static void SetPhase(Phase _phase)
    {
        if(_phase == Phase.NextPhase) phase++;
        else phase = _phase;
    }

    void PhaseSwitchAbilityUsed(Unit caster, Unit target, int abilityNumber)
    {
        if(phase == Phase.PlayerVanguard)   GameEvents.QTEStart(QTEController.QTEType.shrinkingCircle, 1);
    }

    protected override void SubscribeListeners()
    {
        GameEvents.onQTEResolved += SwapSupport;
        GameEvents.onSwitchUnitEnd += SwapSupport;
        GameEvents.onUseAbility += PhaseSwitchAbilityUsed;
        //throw new System.NotImplementedException();
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onQTEResolved -= SwapSupport;
        GameEvents.onSwitchUnitEnd -= SwapSupport;
        GameEvents.onUseAbility -= PhaseSwitchAbilityUsed;

        //throw new System.NotImplementedException();
    }

    public bool IsCurrentRoundPlayer()
    {
        return true;
    }

    public enum Phase
    {
        PlayerVanguard,
        EnemyVangaurd,
        PlayerSwap,
        EnemySwap,
        PlayerSupport,
        EnemySupport,
        NextPhase
    }
}
