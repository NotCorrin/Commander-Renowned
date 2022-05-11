using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageDefend : QTEAbility
{
    [SerializeField] int CostVariation = 1;

    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if(!VFX1) VFX1 = Resources.Load("CustomLasers/Mage/MageFlare") as GameObject;
    }

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
        int HealthWeight = Mathf.FloorToInt((1 - (caster.Health / caster.MaxHealth)) * 100);
        int ManaWeight;
        if (caster.unitType == UnitType.Mage || caster.unitType == UnitType.Commander)
        {
            ManaWeight = Mathf.FloorToInt((1 - (caster.Mana / caster.MaxMana)) * 100);
        }
        else return 0;

        return (2 * HealthWeight + ManaWeight) / 3;
    }

    protected override void AbilityUsed(QTEController.QTEResult result)
    {
        int FinalDefense = StatBoost;
        int FinalCost = Cost;

        switch (result)
        {
            case QTEController.QTEResult.Critical:
                {
                    FinalDefense += Variation;
                    FinalCost += CostVariation;
                    break;
                }
            case QTEController.QTEResult.Miss:
                {
                    FinalDefense = Mathf.Max(0, FinalDefense - Variation);
                    FinalCost -= CostVariation;
                    break;
                }
        }

        if (VFX1) Instantiate(VFX1, transform);
        GameEvents.DefenseUp(Caster, FinalDefense);
        GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, Damage));
        GameEvents.onUseMana(Caster, -FinalCost);
    }

    
}
