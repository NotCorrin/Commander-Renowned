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
        if (IsAbilityValid(Caster, Target))
        {
            GameEvents.DefenceUp(Caster, 1);
            GameEvents.HealthChanged(Target, -3);
            GameEvents.UseAmmo(Caster, 1);
        }
        //reduce damage from next attack
    }

    public override bool IsAbilityValid(Unit Caster, Unit Target)
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
