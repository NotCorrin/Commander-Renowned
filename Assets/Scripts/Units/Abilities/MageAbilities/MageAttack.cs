using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttack : Ability
{
	[SerializeField] int Damage;
	[SerializeField] int Cost;
	public override bool IsAbilityValid (Unit Caster, Unit Target) {
		//does the unit have mana
		if(Caster is MagicUnit) {
			MagicUnit magicUnit = Caster as MagicUnit;
			return magicUnit.Mana > Cost;
		} else if (Caster is CommanderUnit) {
			CommanderUnit casterUnit = Caster as CommanderUnit;
			return casterUnit.Mana > Cost;
		}
		return false;
	}
	public override void UseAbility (Unit Caster, Unit Target) {
		if (IsAbilityValid(Caster, Target)) {
			GameEvents.onHealthChanged(Target, GetDamageCalculation(Caster, Target, Damage));
			GameEvents.onUseMana(Caster, Cost);
		}
	}
	public override int GetMoveWeight () {
		throw new System.NotImplementedException();
	}
}
