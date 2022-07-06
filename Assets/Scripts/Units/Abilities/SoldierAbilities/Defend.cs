using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : QTEAbility
{
    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if (!VFX1)
        {
            VFX1 = Resources.Load("CustomLasers/Soldier/Soldier_Laser") as GameObject;
        }

        if (!VFX2)
        {
            VFX2 = Resources.Load("CustomLasers/Soldier/Shield") as GameObject;
        }

        IsMagic = false;
    }

    public override int GetMoveWeight(Unit caster)
    {
        int healthWeight = Mathf.FloorToInt((1 - ((float)caster.Health / (float)caster.MaxHealth)) * 100);
        if (caster.UnitType == UnitType.Military || caster.UnitType == UnitType.Commander)
        {
            if (caster.Ammo < Cost)
            {
                return 0;
            }

            return 51;
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
        return (FieldController.Main.GetPosition(target) == FieldController.Position.Vanguard) && (FieldController.Main.IsUnitPlayer(target) != isPlayer);
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

        if (VFX2)
        {
            _ = Instantiate(VFX2, transform);
        }

        GameEvents.DefenseUp(Caster, StatBoost);

        AttackWithLaser(finalDamage);

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
        GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, damage));
        FireLaserAtTarget(Target.transform);
    }
}
