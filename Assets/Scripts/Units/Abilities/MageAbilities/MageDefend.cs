using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageDefend : QTEAbility
{
	[SerializeField] int Damage;
    [SerializeField] int DefenseBoost;

    [SerializeField] int DefenseVariation;
    [SerializeField] int CostVariation;

    [SerializeField] GameObject BuffEffect;

    public override bool IsCasterValid (Unit Caster)
    {
        return Caster is MagicUnit || Caster is CommanderUnit;
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

        if (BuffEffect) Instantiate(BuffEffect, transform);
        GameEvents.DefenseUp(Caster, FinalDefense);
        GameEvents.onHealthChanged(Target, -GetDamageCalculation(Caster, Target, Damage));
        GameEvents.onUseMana(Caster, -FinalCost);
    }

    
}
