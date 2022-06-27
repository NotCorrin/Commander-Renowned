using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace : Ability
{
    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if (!VFX1)
        {
            VFX1 = Resources.Load("CustomLasers/Soldier/ReloadParticles") as GameObject;
        }

        IsMagic = false;
    }

    public override int GetMoveWeight(Unit caster)
    {
        int ammoWeight;
        if (caster.UnitType == UnitType.Military || caster.UnitType == UnitType.Commander)
        {
            if (caster.Ammo >= caster.MaxAmmo)
            {
                return 0;
            }

            ammoWeight = Mathf.FloorToInt((1 - ((float)caster.Ammo / (float)caster.MaxAmmo)) * 50);
            return ammoWeight;
        }
        else
        {
            return 0;
        }
    }

    public override void UseAbility(Unit caster, Unit target)
    {
        if (IsAbilityValid(caster, target))
        {
            Instantiate(VFX1, transform);
            GameEvents.onUseAmmo(target, Cost);
            FieldController.main.SwapPlayerUnit(target);
        }
    }

    public override bool IsAbilityValid(Unit caster, Unit target)
    {
        if (caster == target)
        {
            return caster.Ammo < caster.MaxAmmo;
        }

        return false;
    }

    public override bool IsCasterValid(Unit caster)
    {
        return IsAbilityValid(caster, caster);
    }

    public override bool IsTargetValid(Unit target, bool isPlayer)
    {
        return FieldController.main.IsUnitPlayer(target) == isPlayer;
    }
}
