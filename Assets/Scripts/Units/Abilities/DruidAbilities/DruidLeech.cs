using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidLeech : Ability
{
    public override void SetupParams(AbilitySetup setup)
    {
		base.SetupParams(setup);
        if(!VFX1) VFX1 = Resources.Load("CustomLasers/Druid/LeechingVines") as GameObject;
        IsMagic = true;
    }
	public override bool IsCasterValid (Unit Caster)
    {
		return(Caster.Mana >= Cost);
	}    
	public override bool IsTargetValid (Unit Target, bool isPlayer)
    {
        if (isPlayer) return !FieldController.main.IsUnitPlayer(Target);
        else return (FieldController.main.GetPosition(Target) == FieldController.Position.Vanguard) && (FieldController.main.IsUnitPlayer(Target));
	}
	public override void UseAbility (Unit Caster, Unit Target) {
		if (IsAbilityValid(Caster, Target)) {

            GameObject seeds = Instantiate(VFX1, Caster.transform.position, Quaternion.identity);
            seeds.GetComponent<FullAutoFireAtTarget>().SetSmallMissilesHoming(Target.transform);

            GameEvents.ThornsUp(Target, StatBoost);
			GameEvents.UseMana(Caster, Cost);
		}
	}
	public override int GetMoveWeight (Unit caster) {

        if (caster.UnitType == UnitType.Mage || caster.UnitType == UnitType.Commander)
        {
            if (caster.Mana < Cost) return 0;
        }
        else return 0;

        return 100;
    }
}
