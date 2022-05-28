using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinBuff : Ability
{
	public override void SetupParams(AbilitySetup setup)
    {
		base.SetupParams(setup);
        if(!VFX1) VFX1 = Resources.Load("CustomLasers/Mage/BuffParticles") as GameObject;
        isMagic = true;
        //buffs.add(new Buff(BuffType.Attack))
    }
	public override bool IsCasterValid (Unit Caster)
    {
        return Caster.Mana >= Cost;
	}    
	public override bool IsTargetValid (Unit Target, bool isPlayer)
    {
		return (FieldController.main.GetPosition(Target) == FieldController.Position.Vanguard) && (FieldController.main.IsUnitPlayer(Target) == isPlayer);
	}
	public override void UseAbility (Unit Caster, Unit Target) {
		if (IsAbilityValid(Caster, Target)) {
            Instantiate(VFX1, Target.transform);
			GameEvents.AttackUp(Target, StatBoost);
			GameEvents.UseMana(Caster, Cost);
		}
	}
	public override int GetMoveWeight (Unit caster) {

        int HealthWeight = Mathf.FloorToInt(((float)caster.Health / (float)caster.MaxHealth) * 100);
        int ManaWeight;

        if (caster.unitType == UnitType.Mage || caster.unitType == UnitType.Commander)
        {
            if (caster.Mana < Cost) return 0;

            ManaWeight = Mathf.FloorToInt(((float)caster.Mana / (float)caster.MaxMana) * 100);

        }
        else return 0;

        return (HealthWeight + 2 * ManaWeight) / 3;
    }
}
