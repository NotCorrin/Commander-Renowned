using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttack : Ability
{
	[SerializeField] int Damage;
	[SerializeField] int Cost;

    [SerializeField] int DamageVariation;
    [SerializeField] int CostVariation;

    private Unit Caster;
    private Unit Target;


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


	public override void UseAbility (Unit Caster, Unit Target)
    {
        if (IsAbilityValid(Caster, Target))
        {
            this.Caster = Caster;
            this.Target = Target;
            GameEvents.QTEStart(QTEController.QTEType.shrinkingCircle);
            GameEvents.onQTEResolved += AbilityUsed;
        }
    }


	public override int GetMoveWeight ()
    {
		throw new System.NotImplementedException();
	}

    private void AbilityUsed(QTEController.QTEResult result)
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
