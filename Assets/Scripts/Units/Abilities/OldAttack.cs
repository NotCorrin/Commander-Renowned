using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldAttack : QTEAbility
{
    
    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if(!VFX1) VFX1 = Resources.Load("CustomLasers/Soldier/Soldier_Laser") as GameObject;
        if(!VFX2) VFX2 = Resources.Load("CustomLasers/Soldier/Shield") as GameObject;
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

    protected override void AbilityUsed(GameManager.QTEResult result)
    {
        int FinalDefense = StatBoost;

        switch (result)
        {
            case GameManager.QTEResult.Critical:
                {
                    FinalDefense += Variation;
                    break;
                }
            case GameManager.QTEResult.Miss:
                {
                    FinalDefense = Mathf.Max(0, FinalDefense - Variation);
                    break;
                }
        }

        if (VFX2) Instantiate(VFX2, transform);
        GameEvents.AttackUp(Caster, FinalDefense);

        GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, Damage));
        FireLaserAtTarget(Target.transform);

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
        }
    }

    void AttackWithLaser(int damage)
    {
        GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, damage));
        FireLaserAtTarget(Target.transform);
    }
}
