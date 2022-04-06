using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBuff : Ability
{
	public override bool IsAbilityValid (Unit Caster, Unit Target) {
		if (Caster is MagicUnit) {
			MagicUnit magicUnit = Caster as MagicUnit;
			return magicUnit.Mana > 0;
		} else if (Caster is CommanderUnit) {
			CommanderUnit casterUnit = Caster as CommanderUnit;
			return casterUnit.Mana > 0;
		}

		return false;
	}
	public override void UseAbility (Unit Caster, Unit Target) {
		if (IsAbilityValid(Caster, Target)) {
			GameEvents.AttackUp(Caster, 1);
			GameEvents.UseMana(Caster, 1);
		}
	}
	public override int GetMoveWeight () {
		throw new System.NotImplementedException();
	}
}
