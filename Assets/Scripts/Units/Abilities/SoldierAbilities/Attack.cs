using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : QTEAbility
{
    [SerializeField] int TotalBaseDamage;

    [SerializeField] int DamageVariation;

    [SerializeField] int AttackBoost;

    [SerializeField] GameObject LaserShot;

    [SerializeField] float secondShotDelay = 0.2f;

    int FinalDamage;

    bool secondShotTrigger;

    float secondShotTimer;

    public override int GetMoveWeight(Unit caster)
    {
        int HealthWeight = Mathf.FloorToInt((caster.Health / caster.MaxHealth) * 100);
        int AmmoWeight;
        if (caster is MilitaryUnit)
        {
            MilitaryUnit militaryCaster = caster as MilitaryUnit;

            if (militaryCaster.Ammo < Cost) return 0;

            AmmoWeight = Mathf.FloorToInt((militaryCaster.Ammo / militaryCaster.MaxAmmo) * 100);

        }
        else if (caster is CommanderUnit)
        {
            CommanderUnit commanderCaster = caster as CommanderUnit;
            if (commanderCaster.Ammo < Cost) return 0;

            AmmoWeight = Mathf.FloorToInt((commanderCaster.Ammo / commanderCaster.MaxAmmo) * 100);

        }

        else return 0;

        return (2 * HealthWeight + AmmoWeight) / 3;
    }

    protected override void AbilityUsed(QTEController.QTEResult result)
    {
        FinalDamage = TotalBaseDamage;

        switch (result)
        {
            case QTEController.QTEResult.Critical:
                {
                    FinalDamage += DamageVariation;
                    break;
                }
            case QTEController.QTEResult.Miss:
                {
                    FinalDamage -= DamageVariation;
                    break;
                }
        }


        GameEvents.AttackUp(Caster, AttackBoost);

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
		if (Caster is MilitaryUnit) 
		{
			MilitaryUnit casterUnit = Caster as MilitaryUnit;
			return(casterUnit.Ammo >= Cost);
		} 
		else if (Caster is CommanderUnit) 
		{
			CommanderUnit casterUnit = Caster as CommanderUnit;
			return(casterUnit.Ammo >= Cost);
		} else return false;
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
