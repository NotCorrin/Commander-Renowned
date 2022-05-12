using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : QTEAbility
{
    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if(!VFX1) VFX1 = Resources.Load("CustomLasers/Soldier/Soldier_Laser") as GameObject;
    }

    public override int GetMoveWeight(Unit caster)
    {
        int BuffWeight = caster.Attack * 30;
        if (caster.unitType == UnitType.Military || caster.unitType == UnitType.Commander)
        {
            if (caster.Ammo < Cost) return 0;
            return (2 * BuffWeight + 50) / 3;
        }
        else return 0;
    }

    protected override void AbilityUsed(QTEController.QTEResult result)
    {
        int FinalDamage = Damage;

        switch (result)
        {
            case QTEController.QTEResult.Critical:
                {
                    FinalDamage += base.Variation;
                    break;
                }
            case QTEController.QTEResult.Miss:
                {
                    FinalDamage -= base.Variation;
                    break;
                }
        }

        GameEvents.BaseAttackUp(Caster, 3);
        GameEvents.BaseDefenseUp(Caster, -3);

        AttackWithLaser(Mathf.FloorToInt(FinalDamage));

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
        if(Target)
        {
            GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, damage));
            FireLaserAtTarget(Target.transform);
        }
    }

    private void Update()
    {
        
    }
}
