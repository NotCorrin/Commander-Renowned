using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldAttack : QTEAbility
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
        int finalDefense = StatBoost;

        switch (result)
        {
            case GameManager.QTEResult.Critical:
                {
                    finalDefense += Variation;
                    break;
                }

            case GameManager.QTEResult.Miss:
                {
                    finalDefense = Mathf.Max(0, finalDefense - Variation);
                    break;
                }
        }

        if (VFX2)
        {
            _ = Instantiate(VFX2, transform);
        }

        GameEvents.AttackUp(Caster, finalDefense);

        GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, Damage));
        FireLaserAtTarget(Target.transform);

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
}
