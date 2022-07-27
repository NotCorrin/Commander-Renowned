using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermDefense : Status
{
    /// <summary>
    /// Gets the name of the perm defence buff.
    /// </summary>
    public override string Name { get => "permDefence"; }

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
            Afflicted.BonusDefense += changeAmount;
        }
    }
}
