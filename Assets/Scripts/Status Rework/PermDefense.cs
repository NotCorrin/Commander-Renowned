using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermDefense : Status
{
    public override Sprite GetIcon()
    {
        throw new System.NotImplementedException();
    }

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
