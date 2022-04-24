using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageDefend : QTEAbility
{
	[SerializeField] int Damage;
	[SerializeField] int Cost;
    [SerializeField] int DefenseBoost;

    [SerializeField] int DefenseVariation;
    [SerializeField] int CostVariation;
    

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

    protected override QTEController.QTEType GetQTEType()
    {
        return QTEController.QTEType.shrinkingCircle;
    }

    public override int GetMoveWeight (Unit caster)
    {
        int HealthWeight = Mathf.FloorToInt(1 - (caster.Health / caster.MaxHealth) * 100);
        int ManaWeight;
        if (caster is MageUnit)
        {
            MageUnit mageCaster = caster as MageUnit;
            ManaWeight = Mathf.FloorToInt((1 - (mageCaster.Mana / mageCaster.MaxMana)) * 100);

        }
        else if (caster is CommanderUnit)
        {
            CommanderUnit commanderCaster = caster as CommanderUnit;
            ManaWeight = Mathf.FloorToInt((1 - (commanderCaster.Mana / commanderCaster.MaxMana)) * 100);

        }
        else return 0;

        return (2 * HealthWeight + ManaWeight) / 3;
    }

    protected override void AbilityUsed(QTEController.QTEResult result)
    {
        int FinalDefense = DefenseBoost;
        int FinalCost = Cost;

        switch (result)
        {
            case QTEController.QTEResult.Critical:
                {
                    FinalDefense += DefenseVariation;
                    FinalCost += CostVariation;
                    break;
                }
            case QTEController.QTEResult.Miss:
                {
                    FinalDefense = Mathf.Max(0, FinalDefense - DefenseVariation);
                    FinalCost -= CostVariation;
                    break;
                }
        }

        GameEvents.DefenseUp(Caster, FinalDefense);
        GameEvents.onHealthChanged(Target, GetDamageCalculation(Caster, Target, Damage));
        GameEvents.onUseMana(Caster, -FinalCost);
    }

    
}
