using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : Listener
{
    public static RoundController main;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void SubscribeListeners()
    {
        
    }

    protected override void UnsubscribeListeners()
    {
        throw new System.NotImplementedException();
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
