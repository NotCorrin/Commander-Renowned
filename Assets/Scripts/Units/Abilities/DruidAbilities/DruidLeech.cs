using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidLeech : Ability
{
    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if (!VFX1)
        {
            VFX1 = Resources.Load("CustomLasers/Druid/LeechingVines") as GameObject;
        }

        IsMagic = true;
    }

    public override bool IsCasterValid(Unit caster)
    {
        return caster.Mana >= Cost;
    }

    public override bool IsTargetValid(Unit target, bool isPlayer)
    {
        if (isPlayer)
        {
            return !FieldController.main.IsUnitPlayer(target);
        }
        else
        {
            return (FieldController.main.GetPosition(target) == FieldController.Position.Vanguard) && FieldController.main.IsUnitPlayer(target);
        }
    }

    public override void UseAbility(Unit caster, Unit target)
    {
        if (IsAbilityValid(caster, target))
        {
            GameObject seeds = Instantiate(VFX1, caster.transform.position, Quaternion.identity);
            seeds.GetComponent<FullAutoFireAtTarget>().SetSmallMissilesHoming(target.transform);

            GameEvents.ThornsUp(target, StatBoost);
            GameEvents.UseMana(caster, Cost);
        }
    }

    public override int GetMoveWeight(Unit caster)
    {
        if (caster.UnitType == UnitType.Mage || caster.UnitType == UnitType.Commander)
        {
            if (caster.Mana < Cost)
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }

        return 100;
    }
}
