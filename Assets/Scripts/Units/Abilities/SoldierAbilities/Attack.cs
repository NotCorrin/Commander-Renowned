using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : QTEAbility
{
    [SerializeField] float secondShotDelay = 0.2f;

    int FinalDamage;

    bool secondShotTrigger;

    float secondShotTimer;

    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if(!VFX1) VFX1 = Resources.Load("CustomLasers/Soldier/Soldier_Laser") as GameObject;
        IsMagic = false;
    }

    public override int GetMoveWeight(Unit caster)
    {
        int BuffWeight = GetTotalDamageBuffs(caster) * 30;
        if (caster.UnitType == UnitType.Military || caster.UnitType == UnitType.Commander)
        {
            if (caster.Ammo < Cost) return 0;
            return BuffWeight + Damage * 10;
        }
        else return 0;
    }

    public override void UseAbility(Unit Caster, Unit Target)
    {
        GameEvents.AccuracyUp(Caster, StatBoost);
        base.UseAbility(Caster, Target);
    }

    protected override void AbilityUsed(GameManager.QTEResult result)
    {
        FinalDamage = Damage;

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

        AttackWithLaser(Mathf.FloorToInt((float)FinalDamage / 2));

        secondShotTimer = secondShotDelay;
        secondShotTrigger = true;

        GameEvents.UseAmmo(Caster, Cost);
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

    void FireLaserAtTarget(Transform targetTransform)
    {
        if (VFX1)
        {
            GameObject SpawnedLaser = Instantiate(VFX1, transform);
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
        if(Target)
        {
            FireLaserAtTarget(Target.transform);
            GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, damage));
        }
    }
        
    private void Update()
    {
        if (secondShotTrigger && Target)
        {
            if ((secondShotTimer -= Time.deltaTime) <= 0)
            {
                AttackWithLaser(Mathf.CeilToInt((float)FinalDamage/2));
                secondShotTrigger = false;
            }
        }
        
    }
}
