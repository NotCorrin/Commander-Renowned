using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBuff : Status
{
    public override Sprite GetIcon()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnChanged(int changeAmount)
    {
        if (Afflicted)
        {
            Afflicted.BonusDefense += changeAmount;
        }
    }
}
