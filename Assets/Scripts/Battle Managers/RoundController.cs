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
        phase = Phase.ChooseAttack;
    }

    void SwapSupport(QTEController.QTEResult QTEResult)
    {
        phase = Phase.SwapSupport;
    }

    void ChooseSupport(Unit unitSwitched)
    {
        phase = Phase.ChooseSupport;
    }

    protected override void SubscribeListeners()
    {
        GameEvents.onQTEResolved += SwapSupport;
        GameEvents.onSwitchUnitEnd += ChooseSupport;
        //throw new System.NotImplementedException();
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onQTEResolved -= SwapSupport;

        //throw new System.NotImplementedException();
    }

    public bool IsCurrentRoundPlayer()
    {
        return true;
    }

    public enum Phase
    {
        ChooseAttack,
        SwapSupport,
        ChooseSupport
    }
}
