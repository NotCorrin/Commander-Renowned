using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechAttack : QTEAbility
{
    public override bool IsCasterValid(Unit caster)
    {
        return caster.Ammo >= Cost;
    }

    public override bool IsTargetValid(Unit target, bool isPlayer)
    {
        return (FieldController.Main.GetPosition(target) == FieldController.Position.Vanguard) && (FieldController.Main.IsUnitPlayer(target) != isPlayer);
    }

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
        int buffWeight = (caster.Attack * 15) + ((caster.Ammo - 2) * 15);
        if (caster.UnitType == UnitType.Military || caster.UnitType == UnitType.Commander)
        {
            if (caster.Ammo < Cost)
            {
                return 0;
            }

            return ((2 * buffWeight) + 50) / 3;
        }
        else
        {
            return 0;
        }
    }

    protected override void AbilityUsed(GameManager.QTEResult result)
    {
        int finalDamage = Damage + Caster.Ammo;

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

        AttackWithLaser(finalDamage);

        GameEvents.UseAmmo(Caster, Caster.Ammo);
    }

    protected override GameManager.QTEType GetQTEType()
    {
        return GameManager.QTEType.TimingBar;
    }

    private void FireMissileAtTarget(Transform targetTransform)
    {
        if (VFX1)
        {
            GameObject spawnedMissile = Instantiate(VFX1, transform);
            spawnedMissile.transform.LookAt(targetTransform);
            spawnedMissile.GetComponent<FullAutoFireAtTarget>().SetSmallMissilesHoming(targetTransform);
        }
    }

    private void AttackWithLaser(int damage)
    {
        if (Target)
        {
            GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, damage));
            FireMissileAtTarget(Target.transform);
            GameEvents.BaseAttackUp(Caster, StatBoost);
            GameEvents.BaseDefenseUp(Caster, StatBoost);
        }
    }
}
