using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttack : QTEAbility
{
    [SerializeField] int CostVariation = -1; //unused for now (cbf)

    public override void SetupParams(AbilitySetup setup)
    {
        VFX1 = Resources.Load("CustomLasers/Mage/Mage_Explosion") as GameObject;
        isMagic = true;
        base.SetupParams(setup);
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
        int HealthWeight = Mathf.FloorToInt(1 - ((float)caster.Health / (float)caster.MaxHealth) * 100);
        int ManaWeight;
        int BuffWeight = GetTotalDamageBuffs(caster) * 20;
        if (caster.UnitType == UnitType.Mage || caster.UnitType == UnitType.Commander)
        {
            ManaWeight = Mathf.FloorToInt((1 - ((float)caster.Mana / (float)caster.MaxMana)) * 100);
        }
        else return 0;

        return (HealthWeight+2 * ManaWeight)/3 + BuffWeight;
    }

    protected override void AbilityUsed(GameManager.QTEResult result)
    {
        int FinalDamage = Damage;
        int FinalCost = Cost;

        switch (result)
        {
            case GameManager.QTEResult.Critical:
                {
                    FinalDamage += Variation;
                    FinalCost += CostVariation;
                    Debug.Log("Critical");
                    break;
                }
            case GameManager.QTEResult.Miss:
                {
                    FinalDamage -= Variation;
                    FinalCost = Mathf.Min(-1, Cost - CostVariation);
                    Debug.Log("Poor");
                    break;
                }
        }

        if (VFX1) Instantiate(VFX1, Target.transform);
        GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, FinalDamage));
        GameEvents.onUseMana(Caster, FinalCost);
    }
}
