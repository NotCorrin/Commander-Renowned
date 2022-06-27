using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : QTEAbility
{
    [SerializeField] private float secondShotDelay = 0.2f;

    private int finalDamage;

    private bool secondShotTrigger;

    private float secondShotTimer;

    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if (!VFX1)
        {
            VFX1 = Resources.Load("CustomLasers/Soldier/Soldier_Laser") as GameObject;
        }

        IsMagic = false;
    }

    public override int GetMoveWeight(Unit caster)
    {
        int buffWeight = GetTotalDamageBuffs(caster) * 30;
        if (caster.UnitType == UnitType.Military || caster.UnitType == UnitType.Commander)
        {
            if (caster.Ammo < Cost)
            {
                return 0;
            }

            return buffWeight + (Damage * 10);
        }
        else
        {
            return 0;
        }
    }

    public override void UseAbility(Unit Caster, Unit Target)
    {
        GameEvents.AccuracyUp(Caster, StatBoost);
        base.UseAbility(Caster, Target);
    }

    public override bool IsCasterValid(Unit caster)
    {
        return caster.Ammo >= Cost;
    }

    public override bool IsTargetValid(Unit target, bool isPlayer)
    {
        return (FieldController.main.GetPosition(target) == FieldController.Position.Vanguard) && (FieldController.main.IsUnitPlayer(target) != isPlayer);
    }

    protected override void AbilityUsed(GameManager.QTEResult result)
    {
        finalDamage = Damage;

        switch (result)
        {
            case GameManager.QTEResult.Critical:
                {
                    finalDamage += Variation;
                    break;
                }

            case GameManager.QTEResult.Miss:
                {
                    finalDamage -= Variation;
                    break;
                }
        }

        AttackWithLaser(Mathf.FloorToInt((float)finalDamage / 2));

        secondShotTimer = secondShotDelay;
        secondShotTrigger = true;

        GameEvents.UseAmmo(Caster, Cost);
    }

    protected override GameManager.QTEType GetQTEType()
    {
        return GameManager.QTEType.TimingBar;
    }

    private void FireLaserAtTarget(Transform targetTransform)
    {
        if (VFX1)
        {
            GameObject spawnedLaser = Instantiate(VFX1, transform);
            spawnedLaser.transform.LookAt(targetTransform);

            spawnedLaser.TryGetComponent<FullAutoFireAtTarget>(out FullAutoFireAtTarget magicMissile);
            if (magicMissile)
            {
                Debug.Log(magicMissile);
                magicMissile.SetSmallMissilesHoming(targetTransform);
                magicMissile.SetBigMissilesHoming(targetTransform);
            }
        }
    }

    private void AttackWithLaser(int damage)
    {
        if (Target)
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
                AttackWithLaser(Mathf.CeilToInt((float)finalDamage / 2));
                secondShotTrigger = false;
            }
        }
    }
}
