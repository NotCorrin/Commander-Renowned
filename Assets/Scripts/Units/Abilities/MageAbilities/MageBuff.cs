using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBuff : Ability
{
	public override bool IsAbilityValid (Unit Caster, Unit Target) {
		throw new System.NotImplementedException();
		//does the unit have mana
		// can the unit use it
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
