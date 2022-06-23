using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : QTEAbility
{
    
    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if(!VFX1) VFX1 = Resources.Load("CustomLasers/Tank/Bombard") as GameObject;
        isMagic = false;
    }

    public override int GetMoveWeight(Unit caster)
    {
        int BuffWeight = FieldController.main.GetAllies(Target).Count * 30;
        if (caster.UnitType == UnitType.Military || caster.UnitType == UnitType.Commander)
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
            LaunchAttackAtTarget(unit.transform);
        }

        GameEvents.UseAmmo(Caster, Cost);
    }

    public override void UseAbility(Unit Caster, Unit Target)
    {
        GameEvents.AccuracyUp(Caster, -2);
        base.UseAbility(Caster, Target);
    }

    protected override GameManager.QTEType GetQTEType()
    {
        return GameManager.QTEType.TimingBar;
    }
    
    public override bool IsCasterValid (Unit Caster)
    {
		return(Caster.Ammo >= Cost);
	}    
	public override bool IsTargetValid (Unit Target, bool isPlayer)
    {
		return (FieldController.main.GetPosition(Target) == FieldController.Position.Vanguard) && (FieldController.main.IsUnitPlayer(Target) != isPlayer);
	}

    void LaunchAttackAtTarget(Transform targetTransform)
    {
        if (VFX1)
        {
            GameObject SpawnedMissile = Instantiate(VFX1, transform);
            SpawnedMissile.GetComponent<FullAutoFireAtTarget>().SetBigMissilesHoming(targetTransform);
        }
    }

    void AttackWithLaser(int damage)
    {
        GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, damage));
        LaunchAttackAtTarget(Target.transform);
    }
}
