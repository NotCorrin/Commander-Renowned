using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAbility : Ability
{
    public override int GetMoveWeight()
    {
        return 0;
    }

    public override void UseAbility(Unit Caster, Unit Target)
    {
        if (!(Caster is MilitaryUnit))
        {
            //attack target in any position
        }
    }
}
