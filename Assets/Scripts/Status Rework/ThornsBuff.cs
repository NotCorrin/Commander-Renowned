using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsBuff : Status
{
    /// <summary>
    /// Gets the name of the thorns buff.
    /// </summary>
    public override string Name { get => "thorns"; }

    protected override void SubscribeListeners()
    {
        base.SubscribeListeners();
        if (Afflicted)
        {
            Afflicted.OnAttackedStatusTrigger += DamageAttacker;
        }
    }

    protected override void UnsubscribeListeners()
    {
        base.UnsubscribeListeners();
        if (Afflicted)
        {
            Afflicted.OnAttackedStatusTrigger -= DamageAttacker;
        }
    }

    private void DamageAttacker(Unit attacker, int damage)
    {
        GameEvents.HealthChanged(attacker, -StackAmount);
    }
}
