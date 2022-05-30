using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySword : QTEAbility
{
    [SerializeField] int CostVariation = -1;

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
        return GameManager.QTEType.shrinkingCircle;
    }

    public override int GetMoveWeight (Unit caster)
    {   
        int HealthWeight = Mathf.FloorToInt(1 - ((float)caster.Health / (float)caster.MaxHealth) * 100);
        int ManaWeight;
        int BuffWeight = GetTotalDamageBuffs(caster) * 20;
        if(GetTotalDefenseBuffs(caster) >= 1) BuffWeight += 50;
        if (caster.unitType == UnitType.Mage || caster.unitType == UnitType.Commander)
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
                    break;
                    Debug.Log("Critical");
                }
            case GameManager.QTEResult.Miss:
                {
                    FinalDamage -= Variation;
                    FinalCost = Mathf.Min(0, Cost - CostVariation);
                    Debug.Log("Poor");
                    break;
                }
        }

        if (Caster.Defense >= 1)
        {
            SpawnVFX(VFX1);
            FinalDamage += 3;
        }
        else SpawnVFX(VFX2);

        GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, FinalDamage));
        GameEvents.onUseMana(Caster, FinalCost);
    }
    void SpawnVFX(GameObject VFXprefab)
    {
        if (VFXprefab) Instantiate(VFXprefab, Target.transform);
    }
}
