using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBuff : Ability
{
	[SerializeField] int buffAmount;
	[SerializeField] int Cost;
	public override bool IsAbilityValid (Unit Caster, Unit Target) {
		bool casterValid;
		bool targetValid;

		if (Caster is MagicUnit) 
		{
			MagicUnit magicUnit = Caster as MagicUnit;
			casterValid = magicUnit.Mana > Cost;
		} 
		else if (Caster is CommanderUnit) 
		{
			CommanderUnit casterUnit = Caster as CommanderUnit;
			casterValid = casterUnit.Mana > Cost;
		} else return false;

		targetValid = (FieldController.main.GetPosition(Target) == FieldController.Position.Vanguard) && FieldController.main.IsUnitPlayer(Target);

		return casterValid && targetValid;

		return false;
	}
	public override void UseAbility (Unit Caster, Unit Target) {
		if (IsAbilityValid(Caster, Target)) {
			GameEvents.AttackUp(Target, buffAmount);
			GameEvents.UseMana(Caster, Cost);
		}
	}
	public override int GetMoveWeight (Unit caster) {
		throw new System.NotImplementedException();
	}
}
