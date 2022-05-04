using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBuff : Ability
{
	[SerializeField] int buffAmount;
	public override bool IsCasterValid (Unit Caster)
    {
		if (Caster is MagicUnit) 
		{
			MagicUnit magicUnit = Caster as MagicUnit;
			return(magicUnit.Mana > Cost);
		} 
		else if (Caster is CommanderUnit) 
		{
			CommanderUnit casterUnit = Caster as CommanderUnit;
			return(casterUnit.Mana > Cost);
		} else return false;
	}    
	public override bool IsTargetValid (Unit Target, bool isPlayer)
    {
		return (FieldController.main.GetPosition(Target) == FieldController.Position.Vanguard) && (FieldController.main.IsUnitPlayer(Target) == isPlayer);
	}
	public override void UseAbility (Unit Caster, Unit Target) {
		if (IsAbilityValid(Caster, Target)) {
			GameEvents.AttackUp(Target, buffAmount);
			GameEvents.UseMana(Caster, Cost);
		}
	}
	public override int GetMoveWeight (Unit caster) {

        int HealthWeight = Mathf.FloorToInt((1 - (caster.Health / caster.MaxHealth)) * 100);
        int ManaWeight;

        if (caster is MageUnit)
        {
            MageUnit mageCaster = caster as MageUnit;

            if (mageCaster.Mana < Cost) return 0;

            ManaWeight = Mathf.FloorToInt((mageCaster.Mana / mageCaster.MaxMana) * 100);

        }
        else if (caster is CommanderUnit)
        {
            CommanderUnit commanderCaster = caster as CommanderUnit;

            if (commanderCaster.Mana < Cost) return 0;

            ManaWeight = Mathf.FloorToInt((commanderCaster.Mana / commanderCaster.MaxMana) * 100);

        }
        else return 0;

        return (HealthWeight + 2 * ManaWeight) / 3;
    }
}
