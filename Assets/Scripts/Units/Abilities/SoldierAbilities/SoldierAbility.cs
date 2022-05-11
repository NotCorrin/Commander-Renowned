using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAbility : Ability
{

    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if(!VFX1) VFX1 = Resources.Load("CustomLasers/Soldier/ReloadParticles") as GameObject;
    }

    public override int GetMoveWeight(Unit caster)
    {
        int HealthWeight = Mathf.FloorToInt((1 - (caster.Health / caster.MaxHealth)) * 100);
        int AmmoWeight;
        if (caster.unitType == UnitType.Military || caster.unitType == UnitType.Commander)
        {
            if (caster.Ammo < Cost) return 0;
            AmmoWeight = Mathf.FloorToInt((1 - (caster.Ammo / caster.MaxAmmo)) * 100);
            return (2 * HealthWeight + AmmoWeight) / 3;
        }
        else return 0;
    }

    public override void UseAbility(Unit Caster, Unit Target)
    {
        if (IsAbilityValid(Caster, Target))
        {
            Instantiate(VFX1, transform);
            GameEvents.onUseAmmo(Target, -Cost);
        }
    }

    public override bool IsAbilityValid(Unit Caster, Unit Target)
    {
        if (Caster == Target)
        {
            return Caster.Ammo < Caster.MaxAmmo;
        }

        return false;
    }
    public override bool IsCasterValid (Unit Caster)
    {
		return IsAbilityValid(Caster, Caster);
	}    
	public override bool IsTargetValid (Unit Target, bool isPlayer)
    {
		return (FieldController.main.IsUnitPlayer(Target) == isPlayer);
	}
}
