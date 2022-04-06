using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageDefend : Ability
{
	[SerializeField] int Damage;
	[SerializeField] int Cost;
	public override bool IsAbilityValid (Unit Caster, Unit Target) {
		bool casterValid;
		bool targetValid;

		if (Caster is MagicUnit) {
			MagicUnit magicUnit = Caster as MagicUnit;
			casterValid = magicUnit.Mana > Cost;
		} 
		else if (Caster is CommanderUnit) 
		{
			CommanderUnit casterUnit = Caster as CommanderUnit;
			casterValid = casterUnit.Mana > Cost;
		} else return false;

		targetValid = (FieldController.main.GetPosition(Target) == FieldController.Position.Vanguard) && !FieldController.main.IsUnitPlayer(Target);

		return casterValid && targetValid;
	}
	public override void UseAbility (Unit Caster, Unit Target) {
		if (IsAbilityValid(Caster, Target)) {
			GameEvents.DefenceUp(Caster, 1);
			GameEvents.onHealthChanged(Target, GetDamageCalculation(Caster, Target, Damage));
			GameEvents.onUseMana(Caster, -Cost);
		}
	}
	public override int GetMoveWeight () {
		throw new System.NotImplementedException();
	}
}
