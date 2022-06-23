using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageDefend : QTEAbility
{
    [SerializeField] int CostVariation = -1;

    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if(!VFX1) VFX1 = Resources.Load("CustomLasers/Mage/MageFlare") as GameObject;
        IsMagic = true;
    }

    public override bool IsCasterValid (Unit Caster)
    {
		return true;
	}    
    public override bool IsTargetValid (Unit Target, bool isPlayer)
    {
		return (FieldController.main.GetPosition(Target) == FieldController.Position.Vanguard) && (FieldController.main.IsUnitPlayer(Target) != isPlayer);
	}

    protected override GameManager.QTEType GetQTEType()
    {
        return GameManager.QTEType.TimingBar;
    }

    public override int GetMoveWeight (Unit caster)
    {
        int HealthWeight = Mathf.FloorToInt((1 - ((float)caster.Health / (float)caster.MaxHealth)) * 30);
        int ManaWeight = 0;
        if (!(caster.UnitType == UnitType.Mage || caster.UnitType == UnitType.Commander))
        {
            return 0;
        }
        else if (caster.Mana >= caster.MaxMana * 0.8f )
        {
            return HealthWeight - 10;
        }
        else
        {
            ManaWeight = Mathf.FloorToInt((1 - ((float)caster.Mana / (float)caster.MaxMana)) * 60);
        }

        return (HealthWeight + ManaWeight)/2 + Random.Range(-10, 10);
    }

    protected override void AbilityUsed(GameManager.QTEResult result)
    {
        int FinalDefense = StatBoost;
        int FinalCost = Cost;

        switch (result)
        {
            case GameManager.QTEResult.Critical:
                {
                    FinalDefense = FinalDefense + Variation;
                    FinalCost--;
                    break;
                }
            case GameManager.QTEResult.Miss:
                {
                    FinalDefense = Mathf.Max(0, FinalDefense - Variation);
                    FinalCost = Mathf.Min(-1, FinalCost - CostVariation);
                    break;
                }
        }

        if (VFX1) Instantiate(VFX1, transform);
        GameEvents.DefenseUp(Caster, FinalDefense);
        //GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, Damage));
        GameEvents.onUseMana(Caster, FinalCost);
    }

    
}
