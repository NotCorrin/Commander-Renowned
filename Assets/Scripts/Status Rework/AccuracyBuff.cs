using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyBuff : Status
{
    /// <summary>
    /// Gets the name of the accuracy buff.
    /// </summary>
    public override string Name { get => "accuracy"; }

    protected override void OnChanged(int changeAmount)
    {
        if (Afflicted)
        {
            Afflicted.BonusAccuracy += changeAmount;
        }
    }
}
