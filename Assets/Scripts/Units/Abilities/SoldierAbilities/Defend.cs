using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : QTEAbility
{
    
    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if(!VFX1) VFX1 = Resources.Load("CustomLasers/Soldier/Soldier_Laser") as GameObject;
        if(!VFX2) VFX2 = Resources.Load("CustomLasers/Soldier/Shield") as GameObject;
    }

    public override int GetMoveWeight(Unit caster)
    {
        int HealthWeight = Mathf.FloorToInt((caster.Health / caster.MaxHealth) * 100);
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
                    FinalDefense += Variation;
                    break;
                }
            case QTEController.QTEResult.Miss:
                {
                    FinalDefense = Mathf.Max(0, FinalDefense - Variation);
                    break;
                }
        }

        if (VFX2) Instantiate(VFX2, transform);
        GameEvents.DefenseUp(Caster, FinalDefense);

        GameEvents.HealthChanged(Target, -GetDamageCalculation(Caster, Target, Damage));
        FireLaserAtTarget(Target.transform);

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

    void FireLaserAtTarget(Transform targetTransform)
    {
        if (VFX1)
        {
            GameObject SpawnedLaser = Instantiate(VFX1, transform);
            SpawnedLaser.transform.LookAt(targetTransform);
        }
    }

    void AttackWithLaser(int damage)
    {
        GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, damage));
        FireLaserAtTarget(Target.transform);
    }
}
