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

    public override bool IsAbilityValid(Unit Caster)
    {
        if (Caster is MilitaryUnit)
        {
            MilitaryUnit casterUnit = Caster as MilitaryUnit;
            return casterUnit.Ammo < casterUnit.MaxAmmo;
        }
        else if (Caster is CommanderUnit)
        {
            CommanderUnit casterUnit = Caster as CommanderUnit;
            return casterUnit.Ammo < casterUnit.MaxAmmo;
        }

        return false;
    }
}
