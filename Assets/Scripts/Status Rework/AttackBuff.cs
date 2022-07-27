using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuff : Status
{
    /// <summary>
    /// Gets the name of the attack buff.
    /// </summary>
    public override string Name { get => "attack"; }

    protected override void OnChanged(int changeAmount)
    {
        if (Afflicted)
        {
            Afflicted.BonusDamage += changeAmount;
        }
    }
}
