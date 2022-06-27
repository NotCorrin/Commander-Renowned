using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : QTEAbility
{
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
        // int BuffWeight = 100;
        if (caster.UnitType == UnitType.Military || caster.UnitType == UnitType.Commander)
        {
            if (caster.Ammo < Cost)
            {
                return 0;
            }

            if (FieldController.main.GetIsVanguard(caster))
            {
                return 100;
            }
            else
            {
                return Mathf.FloorToInt(((float)caster.Ammo / (float)caster.MaxAmmo) * 100);
            }
        }
        else
        {
            return 0;
        }
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
        int finalDamage = Damage;

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

        GameEvents.BaseAttackUp(Caster, StatBoost);

        AttackWithLaser(Mathf.FloorToInt(finalDamage));

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
        }
    }

    private void AttackWithLaser(int damage)
    {
        if (Target)
        {
            GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, damage));
            FireLaserAtTarget(Target.transform);
        }
    }
}
