using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBuff : Status
{
    /// <summary>
    /// Gets the name of the defence buff.
    /// </summary>
    public override string Name { get => "defence"; }

    protected override void OnChanged(int changeAmount)
    {
        if (Afflicted)
        {
            Afflicted.BonusDefense += changeAmount;
        }
    }
}
