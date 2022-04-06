using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * Event list:
 * onBattleStartSelected
 * onUseAbility
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

    public static Action <Unit, Enum> onUseAbility;

    public static void UseAbility(Unit unit, Enum ability )
    {
        if (onUseAbility != null)
        {
            onUseAbility(unit, ability);
        }
    }
}
