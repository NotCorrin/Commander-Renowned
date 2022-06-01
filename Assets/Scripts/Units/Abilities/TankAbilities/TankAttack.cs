using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : QTEAbility
{
    
    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if(!VFX1) VFX1 = Resources.Load("CustomLasers/Soldier/Soldier_Laser") as GameObject;
        if(!VFX2) VFX2 = Resources.Load("CustomLasers/Soldier/Shield") as GameObject;
        isMagic = false;
    }

    public override int GetMoveWeight(Unit caster)
    {
        int BuffWeight = GetTotalDamageBuffs(caster) * 30;
        if (caster.unitType == UnitType.Military || caster.unitType == UnitType.Commander)
        {
            if (caster.Ammo < Cost) return 0;
            return BuffWeight + Damage * 10;
        }
        else return 0;
    }

    protected override void AbilityUsed(GameManager.QTEResult result)
    {
        int FinalDamage = Damage;

        switch (result)
        {
            case GameManager.QTEResult.Critical:
                {
                    FinalDamage += Variation;
                    break;
                }
            case GameManager.QTEResult.Miss:
                {
                    FinalDamage = Mathf.Max(0, FinalDamage - Variation);
                    break;
                }
        }

        foreach (Unit unit in FieldController.main.GetAllies(Target))
        {
            GameEvents.UnitAttack(Caster, unit, -GetDamageCalculation(Caster, unit, FinalDamage));
            FireLaserAtTarget(unit.transform);
        }
        FireLaserAtTarget(Target.transform);

        GameEvents.UseAmmo(Caster, Cost);
    }

    protected override GameManager.QTEType GetQTEType()
    {
        return GameManager.QTEType.shrinkingCircle;
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
