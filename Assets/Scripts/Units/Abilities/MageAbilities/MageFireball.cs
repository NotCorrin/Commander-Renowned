using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageFireball : Ability
{
    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if (!VFX1)
        {
            VFX1 = Resources.Load("CustomLasers/FireMage/Meteor") as GameObject;
        }

        IsMagic = true;
    }

    public override bool IsCasterValid(Unit caster)
    {
        return caster.Mana >= Cost;
    }

    public override bool IsTargetValid(Unit target, bool isPlayer)
    {
        return (FieldController.Main.GetPosition(target) != FieldController.Position.Vanguard) && (FieldController.Main.IsUnitPlayer(target) != isPlayer) && target;
    }

    public override void UseAbility(Unit caster, Unit target)
    {
        if (IsAbilityValid(caster, target))
        {
            GameObject fireball = Instantiate(VFX1, target.transform.position + new Vector3(Random.Range(-2, 2), 5, Random.Range(-2, 2)), Quaternion.identity);
            fireball.transform.LookAt(target.transform);
            fireball.GetComponent<FullAutoFireAtTarget>().SetBigMissilesHoming(target.transform);

            GameEvents.UnitAttack(caster, target, -GetDamageCalculation(caster, target, Damage));
            GameEvents.AttackUp(target, StatBoost);
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
