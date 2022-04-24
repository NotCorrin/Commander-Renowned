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
		throw new System.NotImplementedException();
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
