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
