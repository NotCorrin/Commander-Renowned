using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrambleShield : QTEAbility
{
    [SerializeField] private int costVariation = -1;

    public override int GetMoveWeight(Unit caster)
    {
        int healthWeight = Mathf.FloorToInt((1 - ((float)caster.Health / (float)caster.MaxHealth)) * 30);
        int manaWeight = 0;
        if (!(caster.UnitType == UnitType.Mage || caster.UnitType == UnitType.Commander))
        {
            return 0;
        }
        else if (caster.Mana >= caster.MaxMana * 0.8f)
        {
            return healthWeight - 10;
        }
        else
        {
            manaWeight = Mathf.FloorToInt((1 - ((float)caster.Mana / (float)caster.MaxMana)) * 60);
        }

        return ((healthWeight + manaWeight) / 2) + Random.Range(-10, 10);
    }

    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if (!VFX1)
        {
            VFX1 = Resources.Load("CustomLasers/Mage/MageFlare") as GameObject;
        }

        IsMagic = true;
    }

    public override bool IsCasterValid(Unit caster)
    {
        return true;
    }

    public override bool IsTargetValid(Unit target, bool isPlayer)
    {
        return (FieldController.Main.GetPosition(target) == FieldController.Position.Vanguard) && (FieldController.Main.IsUnitPlayer(target) != isPlayer);
    }

    protected override GameManager.QTEType GetQTEType()
    {
        return GameManager.QTEType.TimingBar;
    }

    protected override void AbilityUsed(GameManager.QTEResult result)
    {
        int finalThorns = StatBoost;
        int finalCost = Cost;

        switch (result)
        {
            case GameManager.QTEResult.Critical:
                {
                    finalThorns = finalThorns + Variation;
                    break;
                }

            case GameManager.QTEResult.Miss:
                {
                    finalThorns = Mathf.Max(0, finalThorns - Variation);
                    finalCost = Mathf.Min(-1, finalCost - costVariation);
                    break;
                }
        }

        if (VFX1)
        {
            _ = Instantiate(VFX1, transform);
        }

        GameEvents.DefenseUp(Caster, 2);
        GameEvents.ThornsUp(Caster, finalThorns);

        // GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, Damage));
        GameEvents.onUseMana(Caster, finalCost);
    }
}
