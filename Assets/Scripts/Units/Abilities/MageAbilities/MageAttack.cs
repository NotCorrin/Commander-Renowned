using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttack : QTEAbility
{
	[SerializeField] int Damage;
    [SerializeField] int DamageVariation;
    [SerializeField] int CostVariation;

    [SerializeField] GameObject Explosion;

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

        if (Explosion) Instantiate(Explosion, Target.transform);
        GameEvents.onHealthChanged(Target, -GetDamageCalculation(Caster, Target, FinalDamage));
        GameEvents.onUseMana(Caster, -FinalCost);
    }
}
