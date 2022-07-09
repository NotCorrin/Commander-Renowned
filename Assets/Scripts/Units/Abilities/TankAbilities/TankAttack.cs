using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : QTEAbility
{
    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if (!VFX1)
        {
            VFX1 = Resources.Load("CustomLasers/Tank/Bombard") as GameObject;
        }

        IsMagic = false;
    }

    public override int GetMoveWeight(Unit caster)
    {
        int buffWeight = FieldController.Main.GetAllies(Target).Count * 30;
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
        GameEvents.AccuracyUp(Caster, -2);
        base.UseAbility(Caster, Target);
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
                    finalDamage = Mathf.Max(0, finalDamage - Variation);
                    break;
                }
        }

        foreach (Unit unit in FieldController.Main.GetAllies(Target))
        {
            GameEvents.UnitAttack(Caster, unit, -Mathf.Max(finalDamage + Mathf.FloorToInt(Caster.BonusDamage / 2) - unit.DamageReduction, 0));
            LaunchAttackAtTarget(unit.transform);
        }

        GameEvents.UseAmmo(Caster, Cost);
    }

    protected override GameManager.QTEType GetQTEType()
    {
        return GameManager.QTEType.TimingBar;
    }

    private void LaunchAttackAtTarget(Transform targetTransform)
    {
        if (VFX1)
        {
            GameObject spawnedMissile = Instantiate(VFX1, transform);
            spawnedMissile.GetComponent<FullAutoFireAtTarget>().SetBigMissilesHoming(targetTransform);
        }
    }
}
