using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * Event list:
 * onBattleStartSelected
 */

public static class MenuEvents
{
    public static Action onBattleStartSelected;
    public static void BattleStartSelected()
    {
        if (onBattleStartSelected != null)
        {
            onBattleStartSelected();
        }
    }
    // Start is called before the first frame update
}
