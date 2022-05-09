using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBuff : Ability
{
	public override bool IsCasterValid (Unit Caster)
    {
		return(Caster.Mana > Cost);
	}    
	public override bool IsTargetValid (Unit Target, bool isPlayer)
    {
		return (FieldController.main.GetPosition(Target) == FieldController.Position.Vanguard) && (FieldController.main.IsUnitPlayer(Target) == isPlayer);
	}
	public override void UseAbility (Unit Caster, Unit Target) {
		if (IsAbilityValid(Caster, Target)) {
			GameEvents.AttackUp(Target, StatBoost);
			GameEvents.UseMana(Caster, Cost);
		}
	}
	public override int GetMoveWeight (Unit caster) {

        int HealthWeight = Mathf.FloorToInt((1 - (caster.Health / caster.MaxHealth)) * 100);
        int ManaWeight;

        if (caster.unitType == UnitType.Mage || caster.unitType == UnitType.Commander)
        {
            if (caster.Mana < Cost) return 0;

            ManaWeight = Mathf.FloorToInt((caster.Mana / caster.MaxMana) * 100);

        }
        else return 0;

        return (HealthWeight + 2 * ManaWeight) / 3;
    }
}
