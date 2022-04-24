using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAbility : Ability
{
    [SerializeField] int AmmoRestored;

    public override int GetMoveWeight(Unit caster)
    {
        return 0;
    }

    public override void UseAbility(Unit Caster, Unit Target)
    {
        if (IsAbilityValid(Caster, Target))
        {
            GameEvents.onUseAmmo(Target, -AmmoRestored);
        }
    }

    public override bool IsAbilityValid(Unit Caster, Unit Target)
    {
        if (Caster == Target)
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
        }

        return false;
    }
}
