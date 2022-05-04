using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAbility : Ability
{
    public override int GetMoveWeight(Unit caster)
    {
        int HealthWeight = Mathf.FloorToInt((1 - (caster.Health / caster.MaxHealth)) * 100);
        int AmmoWeight;

        if (caster is MilitaryUnit)
        {
            MilitaryUnit militaryCaster = caster as MilitaryUnit;

            AmmoWeight = Mathf.FloorToInt((1 - (militaryCaster.Ammo / militaryCaster.MaxAmmo)) * 100);

        }
        else if (caster is CommanderUnit)
        {
            CommanderUnit commanderCaster = caster as CommanderUnit;

            AmmoWeight = Mathf.FloorToInt((1 - (commanderCaster.Ammo / commanderCaster.MaxAmmo)) * 100);

        }
        else return 0;

        return (HealthWeight + 2 * AmmoWeight) / 3;
    }

    public override void UseAbility(Unit Caster, Unit Target)
    {
        if (IsAbilityValid(Caster, Target))
        {
            GameEvents.onUseAmmo(Target, -Cost);
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
    public override bool IsCasterValid (Unit Caster)
    {
		return IsAbilityValid(Caster, Caster);
	}    
	public override bool IsTargetValid (Unit Target, bool isPlayer)
    {
		return (FieldController.main.IsUnitPlayer(Target) != isPlayer);
	}
}
