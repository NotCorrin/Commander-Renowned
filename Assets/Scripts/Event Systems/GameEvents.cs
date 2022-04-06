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
}
