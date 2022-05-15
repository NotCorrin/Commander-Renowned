using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageFireball : Ability
{
	public override void SetupParams(AbilitySetup setup)
    {
		base.SetupParams(setup);
        if(!VFX1) VFX1 = Resources.Load("CustomLasers/FireMage/Meteor") as GameObject;
    }
	public override bool IsCasterValid (Unit Caster)
    {
		return(Caster.Mana >= Cost);
	}    
	public override bool IsTargetValid (Unit Target, bool isPlayer)
    {
		return (FieldController.main.GetPosition(Target) != FieldController.Position.Vanguard) && (FieldController.main.IsUnitPlayer(Target) != isPlayer);
	}
	public override void UseAbility (Unit Caster, Unit Target) {
		if (IsAbilityValid(Caster, Target)) {

            GameObject fireball = Instantiate(VFX1, Target.transform.position + new Vector3(Random.Range(-2,2), 5, Random.Range(-2, 2)), Quaternion.identity);
            fireball.transform.LookAt(Target.transform);
            fireball.GetComponent<FullAutoFireAtTarget>().SetBigMissilesHoming(Target.transform);

            GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, Damage));
			GameEvents.AttackUp(Target, StatBoost);
			GameEvents.UseMana(Caster, Cost);
		}
	}
	public override int GetMoveWeight (Unit caster) {

        if (caster.unitType == UnitType.Mage || caster.unitType == UnitType.Commander)
        {
            if (caster.Mana < Cost) return 0;


        }
        else return 0;

        return 100;
    }
}
