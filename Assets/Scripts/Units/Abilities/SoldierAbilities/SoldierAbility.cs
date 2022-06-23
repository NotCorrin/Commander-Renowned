using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAbility : Ability
{

    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if(!VFX1) VFX1 = Resources.Load("CustomLasers/Soldier/ReloadParticles") as GameObject;
        IsMagic = false;
    }

    public override int GetMoveWeight(Unit caster)
    {
        int AmmoWeight;
        if (caster.UnitType == UnitType.Military || caster.UnitType == UnitType.Commander)
        {
            if (caster.Ammo >= caster.MaxAmmo) return 0;
            AmmoWeight = Mathf.FloorToInt((1 - ((float)caster.Ammo / (float)caster.MaxAmmo)) * 50);
            return AmmoWeight;
        }
        else return 0;
    }

    public override void UseAbility(Unit Caster, Unit Target)
    {
        if (IsAbilityValid(Caster, Target))
        {
            Instantiate(VFX1, transform);
            GameEvents.onUseAmmo(Target, Cost);
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
