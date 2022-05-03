using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : QTEAbility
{
    [SerializeField] int Damage;

    [SerializeField] int DamageVariation;

    public override int GetMoveWeight(Unit caster)
    {
        int HealthWeight = Mathf.FloorToInt((caster.Health / caster.MaxHealth) * 100);
        int AmmoWeight;
        if (caster is MilitaryUnit)
        {
            MilitaryUnit militaryCaster = caster as MilitaryUnit;

            if (militaryCaster.Ammo < Cost) return 0;

            AmmoWeight = Mathf.FloorToInt((militaryCaster.Ammo / militaryCaster.MaxAmmo) * 100);

        }
        else if (caster is CommanderUnit)
        {
            CommanderUnit commanderCaster = caster as CommanderUnit;
            if (commanderCaster.Ammo < Cost) return 0;

            AmmoWeight = Mathf.FloorToInt((commanderCaster.Ammo / commanderCaster.MaxAmmo) * 100);

        }

        else return 0;

        return (2 * HealthWeight + AmmoWeight) / 3;
    }

    protected override void AbilityUsed(QTEController.QTEResult result)
    {
        int FinalDamage = Damage;

        switch (result)
        {
            case QTEController.QTEResult.Critical:
                {
                    FinalDamage += DamageVariation;
                    break;
                }
            case QTEController.QTEResult.Miss:
                {
                    FinalDamage -= DamageVariation;
                    break;
                }
        }
        

        GameEvents.AttackUp(Caster, 1);
        GameEvents.HealthChanged(Target, -GetDamageCalculation(Caster, Target, Damage));
        GameEvents.UseAmmo(Caster, Cost);
    }

    protected override QTEController.QTEType GetQTEType()
    {
        return QTEController.QTEType.shrinkingCircle;
    }

    public override bool IsCasterValid (Unit Caster)
    {
		if (Caster is MilitaryUnit) 
		{
			MilitaryUnit casterUnit = Caster as MilitaryUnit;
			return(casterUnit.Ammo >= Cost);
		} 
		else if (Caster is CommanderUnit) 
		{
			CommanderUnit casterUnit = Caster as CommanderUnit;
			return(casterUnit.Ammo >= Cost);
		} else return false;
	}    
	public override bool IsTargetValid (Unit Target)
    {
		return (FieldController.main.GetPosition(Target) == FieldController.Position.Vanguard) && !FieldController.main.IsUnitPlayer(Target);
	}
}
