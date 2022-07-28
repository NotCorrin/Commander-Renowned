using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermAttackBuff : Status
{
    /// <summary>
    /// Gets the name of the perm attack buff.
    /// </summary>
    public override string Name { get => "permAttack"; }

    protected override void DecayStatus()
    {
        if (StackAmount > 0)
        {
            AddStacks(-1);
        }
    }

    protected override void OnChanged(int changeAmount)
    {
        if (Afflicted)
        {
            Afflicted.BonusDamage += changeAmount;
        }
    }
}
