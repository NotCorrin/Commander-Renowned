using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechAttack : QTEAbility
{
    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if(!VFX1) VFX1 = Resources.Load("CustomLasers/Soldier/Soldier_Laser") as GameObject;
        isMagic = false;
    }

    public override int GetMoveWeight(Unit caster)
    {
        int BuffWeight = caster.Attack * 15 + (caster.Ammo-2) * 15;
        if (caster.unitType == UnitType.Military || caster.unitType == UnitType.Commander)
        {
            if (caster.Ammo < Cost) return 0;
            return (2 * BuffWeight + 50) / 3;
        }
        else return 0;
    }

    protected override void AbilityUsed(GameManager.QTEResult result)
    {
        int FinalDamage = Damage + Caster.Ammo;        

        switch (result)
        {
            case GameManager.QTEResult.Critical:
                {
                    FinalDamage += base.Variation;
                    break;
                }
            case GameManager.QTEResult.Miss:
                {
                    FinalDamage -= base.Variation;
                    break;
                }
        }

        AttackWithLaser(FinalDamage);

        GameEvents.UseAmmo(Caster, Caster.Ammo);
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

    void FireMissileAtTarget(Transform targetTransform)
    {
        if (VFX1)
        {
            GameObject SpawnedMissile = Instantiate(VFX1, transform);
            SpawnedMissile.transform.LookAt(targetTransform);
            SpawnedMissile.GetComponent<FullAutoFireAtTarget>().SetSmallMissilesHoming(targetTransform);
        }
    }

    void AttackWithLaser(int damage)
    {
        if(Target)
        {
            GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, damage));
            FireMissileAtTarget(Target.transform);
            GameEvents.BaseAttackUp(Caster, -2);
            GameEvents.BaseDefenseUp(Caster, -2);
        }
    }

    private void Update()
    {
        
    }
}
