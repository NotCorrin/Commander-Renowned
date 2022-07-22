using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyBuff : Status
{
    public override Sprite GetIcon()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnChanged(int changeAmount)
    {
        if (Afflicted)
        {
            Afflicted.BonusAccuracy += changeAmount;
        }
    }
}
