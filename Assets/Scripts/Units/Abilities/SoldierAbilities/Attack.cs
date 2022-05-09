using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : QTEAbility
{
    [SerializeField] GameObject LaserShot;

    [SerializeField] float secondShotDelay = 0.2f;

    int FinalDamage;

    bool secondShotTrigger;

    float secondShotTimer;

    public override void SetupParams(AbilitySetup setup)
    {
        if(setup is AttackSetup)
        {
            AttackSetup attackSetup = setup as AttackSetup;
            LaserShot = attackSetup.LaserShot;
            secondShotDelay = attackSetup.secondShotDelay;
        }
        else
        {
            Debug.Log("tf");
        }
        base.SetupParams(setup);
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
        FinalDamage = Damage;

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

        GameEvents.AttackUp(Caster, StatBoost);
        GameEvents.HealthChanged(Target, -GetDamageCalculation(Caster, Target, base.Damage));

        AttackWithLaser(Mathf.FloorToInt(FinalDamage / 2));

        secondShotTimer = secondShotDelay;
        secondShotTrigger = true;

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
        if (LaserShot)
        {
            GameObject SpawnedLaser = Instantiate(LaserShot, transform);
            SpawnedLaser.transform.LookAt(targetTransform);

            SpawnedLaser.TryGetComponent<FullAutoFireAtTarget>(out FullAutoFireAtTarget MagicMissile);
            if (MagicMissile)
            {
                Debug.Log(MagicMissile);
                MagicMissile.SetSmallMissilesHoming(targetTransform);
                MagicMissile.SetBigMissilesHoming(targetTransform);
            }
        }
    }

    void AttackWithLaser(int damage)
    {
        GameEvents.HealthChanged(Target, -GetDamageCalculation(Caster, Target, damage));
        FireLaserAtTarget(Target.transform);
    }

    private void Update()
    {
        if (secondShotTrigger)
        {
            if ((secondShotTimer -= Time.deltaTime) <= 0)
            {
                AttackWithLaser(Mathf.CeilToInt(FinalDamage/2));
                secondShotTrigger = false;
            }
        }
        
    }
}
