using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : QTEAbility
{
    [SerializeField] int DefenseVariation;

    public override int GetMoveWeight(Unit caster)
    {
        int HealthWeight = Mathf.FloorToInt((1 - (caster.Health / caster.MaxHealth)) * 100);
        int AmmoWeight;
        if (caster.unitType == UnitType.Military || caster.unitType == UnitType.Commander)
        {
            if (caster.Ammo < Cost) return 0;
            AmmoWeight = Mathf.FloorToInt((caster.Ammo / caster.MaxAmmo) * 100);
            return (2 * HealthWeight + AmmoWeight) / 3;
        }
        else return 0;
    }

    protected override void AbilityUsed(QTEController.QTEResult result)
    {
        int FinalDefense = StatBoost;

        switch (result)
        {
            case QTEController.QTEResult.Critical:
                {
                    FinalDefense += DefenseVariation;
                    break;
                }
            case QTEController.QTEResult.Miss:
                {
                    FinalDefense = Mathf.Max(0, FinalDefense - DefenseVariation);
                    break;
                }
        }

        GameEvents.DefenseUp(Caster, FinalDefense);
        GameEvents.HealthChanged(Target, -GetDamageCalculation(Caster, Target, Damage));
        GameEvents.UseAmmo(Caster, Cost);
    }

    protected override QTEController.QTEType GetQTEType()
    {
        return QTEController.QTEType.shrinkingCircle;
    }
    
    public override bool IsCasterValid (Unit Caster)
    {
		return(Caster.Ammo >= Cost);
	}    
	public override bool IsTargetValid (Unit Target, bool isPlayer)
    {
		return (FieldController.main.GetPosition(Target) == FieldController.Position.Vanguard) && (FieldController.main.IsUnitPlayer(Target) != isPlayer);
	}
}
