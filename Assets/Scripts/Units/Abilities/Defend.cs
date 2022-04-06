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

    public override bool IsAbilityValid(Unit Caster)
    {
        if (Caster is MilitaryUnit)
        {
            MilitaryUnit casterUnit = Caster as MilitaryUnit;
            return casterUnit.Ammo > 0;
        }
        else if (Caster is CommanderUnit)
        {
            CommanderUnit casterUnit = Caster as CommanderUnit;
            return casterUnit.Ammo > 0;
        }

        return false;
    }
}
