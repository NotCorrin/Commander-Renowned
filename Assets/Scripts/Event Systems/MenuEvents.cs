using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Event list:
 * onBattleStartSelected()
 * onUseAbility()
 * onQTETriggered()
 */

#pragma warning disable SA1201 // Elements should appear in the correct order
#pragma warning disable SA1401 // Fields should be private

public static class MenuEvents
{
    public static Action onBattleStartSelected;

    public static void BattleStartSelected()
    {
        onBattleStartSelected?.Invoke();
    }

    public static Action<Unit, Enum> onUseAbility;

    public static void UseAbility(Unit unit, Enum ability)
    {
        onUseAbility?.Invoke(unit, ability);
    }

    public static Action<GameManager.QTEResult> onQTETriggered;

    public static void QTETriggered(GameManager.QTEResult result)
    {
        onQTETriggered?.Invoke(result);
    }
}

#pragma warning restore SA1201 // Elements should appear in the correct order
#pragma warning restore SA1401 // Fields should be private
