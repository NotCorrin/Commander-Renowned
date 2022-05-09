using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttack : QTEAbility
{
    [SerializeField] int CostVariation;

    public override bool IsCasterValid (Unit Caster)
    {
		return(Caster.Mana > Cost);
	}    
    public override bool IsTargetValid (Unit Target, bool isPlayer)
    {
		return (FieldController.main.GetPosition(Target) == FieldController.Position.Vanguard) && (FieldController.main.IsUnitPlayer(Target) != isPlayer);
	}

    protected override QTEController.QTEType GetQTEType()
    {
        return QTEController.QTEType.shrinkingCircle;
    }

    public override int GetMoveWeight (Unit caster)
    {   
        int HealthWeight = Mathf.FloorToInt((caster.Health / caster.MaxHealth) * 100);
        int ManaWeight;
        if (caster.unitType == UnitType.Mage || caster.unitType == UnitType.Commander)
        {
            ManaWeight = Mathf.FloorToInt((1 - (caster.Mana / caster.MaxMana)) * 100);
        }
        else return 0;

        return (2 * HealthWeight+ManaWeight)/3;
    }

    protected override void AbilityUsed(QTEController.QTEResult result)
    {
        int FinalDamage = Damage;
        int FinalCost = Cost;

        switch (result)
        {
            case QTEController.QTEResult.Critical:
                {
                    FinalDamage += Variation;
                    FinalCost += CostVariation;
                    break;
                }
            case QTEController.QTEResult.Miss:
                {
                    FinalDamage -= Variation;
                    FinalCost -= CostVariation;
                    break;
                }
        }

        GameEvents.onHealthChanged(Target, -GetDamageCalculation(Caster, Target, FinalDamage));
        GameEvents.onUseMana(Caster, -FinalCost);
    }
    
}
