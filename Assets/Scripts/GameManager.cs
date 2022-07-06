using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Listener
{
    /// <summary>
    /// Identifies type of QTE used.
    /// </summary>
    public enum QTEType
    {
        /// <summary>
        /// Bar in which cursor loops through, player must input in 'success zone'
        /// </summary>
        TimingBar,
    }

    public enum QTEResult
    {
        /// <summary>
        /// Perfect success
        /// </summary>
        Critical,

        /// <summary>
        /// Standard in hit zone
        /// </summary>
        Hit,

        /// <summary>
        /// Player missed input window
        /// </summary>
        Miss,
    }

    public enum QTEDisplayResult
    {
        /// <summary>
        /// Display when player hit critical
        /// </summary>
        Perfect,

        /// <summary>
        /// Display when player hit
        /// </summary>
        Good,

        /// <summary>
        /// Display when player misses
        /// </summary>
        Poor,
    }

    protected override void SubscribeListeners()
    {
        MenuEvents.onBattleStartSelected += InitiateBattle;
    }

    protected override void UnsubscribeListeners()
    {
        MenuEvents.onBattleStartSelected -= InitiateBattle;
    }

    private static void InitiateBattle()
    {
        GameEvents.BattleStart();
    }
}
