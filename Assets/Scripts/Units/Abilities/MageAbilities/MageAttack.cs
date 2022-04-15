using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttack : QTEAbility
{
	[SerializeField] int Damage;
	[SerializeField] int Cost;

    [SerializeField] int DamageVariation;
    [SerializeField] int CostVariation;

    public override bool IsAbilityValid (Unit Caster, Unit Target)
    {
		bool casterValid;
		bool targetValid;

		if (Caster is MagicUnit) 
		{
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

    public override int GetMoveWeight ()
    {
		throw new System.NotImplementedException();
	}

    protected override void AbilityUsed(QTEController.QTEResult result)
    {
        int FinalDamage = Damage;
        int FinalCost = Cost;

        switch (result)
        {
            case QTEController.QTEResult.Critical:
                {
                    FinalDamage += DamageVariation;
                    FinalCost += CostVariation;
                    break;
                }
            case QTEController.QTEResult.Miss:
                {
                    FinalDamage -= DamageVariation;
                    FinalCost -= CostVariation;
                    break;
                }
        }

        GameEvents.onHealthChanged(Target, GetDamageCalculation(Caster, Target, FinalDamage));
        GameEvents.onUseMana(Caster, -FinalCost);

        GameEvents.onQTEResolved -= AbilityUsed;
    }
    
}
