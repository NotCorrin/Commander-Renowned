using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttack : Ability
{
	public override bool IsAbilityValid (Unit Caster, Unit Target) {
		//does the unit have mana
		if(Caster is MagicUnit) {
			MagicUnit magicUnit = Caster as MagicUnit;
			return magicUnit.Mana > 0;
		}
		return false;
	}
	public override void UseAbility (Unit Caster, Unit Target) {
		throw new System.NotImplementedException();
		// remove mana from the caster
		// do something to the target
	}
	public override int GetMoveWeight () {
		throw new System.NotImplementedException();
	}
}
