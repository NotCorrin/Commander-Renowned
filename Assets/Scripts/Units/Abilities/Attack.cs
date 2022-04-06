using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Ability
{
    public override int GetMoveWeight()
    {
        return 0;
    }

    public override void UseAbility(Unit Caster, Unit Target)
    {
        GameEvents.HealthChanged(Target, -1);
    }
}
