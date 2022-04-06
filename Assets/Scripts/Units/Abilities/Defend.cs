using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : Ability
{
    public override int GetMoveWeight()
    {
        return 0;
    }

    public override void UseAbility(Unit Caster, Unit Target)
    {
        //reduce damage from next attack
    }
}
