using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttack : QTEAbility
{
    [SerializeField] private int costVariation = -1;

    public override int GetMoveWeight(Unit caster)
    {
        int manaWeight;
        int buffWeight = GetTotalDamageBuffs(caster) * 16;
        if (caster.UnitType == UnitType.Mage || caster.UnitType == UnitType.Commander)
        {
            manaWeight = Mathf.FloorToInt((1 - ((float)caster.Mana / (float)caster.MaxMana)) * 50);
        }
        else
        {
            return 0;
        }

        return (manaWeight / 3) + buffWeight;
    }

    public override void SetupParams(AbilitySetup setup)
    {
        VFX1 = Resources.Load("CustomLasers/Mage/Mage_Explosion") as GameObject;
        IsMagic = true;
        base.SetupParams(setup);
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
        int finalDamage = Damage;
        int finalCost = Cost;

        switch (result)
        {
            case GameManager.QTEResult.Critical:
                {
                    finalDamage += Variation;
                    finalCost += costVariation;
                    Debug.Log("Critical");
                    break;
                }

            case GameManager.QTEResult.Miss:
                {
                    finalDamage -= Variation;
                    finalCost = Mathf.Min(-1, Cost - costVariation);
                    Debug.Log("Poor");
                    break;
                }
        }

        if (VFX1)
        {
            _ = Instantiate(VFX1, Target.transform);
        }

        GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, finalDamage));
        GameEvents.onUseMana(Caster, finalCost);
    }
}
