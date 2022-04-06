using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Listener
{
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
        MenuEvents.onBattleStartSelected += InitiateBattle;
    }

    protected override void UnsubscribeListeners()
    {
        MenuEvents.onBattleStartSelected -= InitiateBattle;
    }

    static void InitiateBattle()
    {
        GameEvents.BattleStart();
    }
}
