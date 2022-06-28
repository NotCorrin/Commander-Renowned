using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySword : QTEAbility
{
    [SerializeField] private int costVariation = -1;

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

    public override int GetMoveWeight(Unit caster)
    {
        int buffWeight = GetTotalDamageBuffs(caster) * 15;
        if (GetTotalDefenseBuffs(caster) >= 1)
        {
            buffWeight += 55;
        }

        Debug.Log(buffWeight);
        return buffWeight;
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
                    Debug.Log("Poor");
                    break;
                }
        }

        if (Caster.Defense >= 1)
        {
            SpawnVFX(VFX2);
            finalDamage += 3;
        }
        else
        {
            SpawnVFX(VFX1);
        }

        GameEvents.UnitAttack(Caster, Target, -GetDamageCalculation(Caster, Target, finalDamage));
        GameEvents.onUseMana(Caster, finalCost);
    }

    private void SpawnVFX(GameObject vFXprefab)
    {
        if (vFXprefab)
        {
            Instantiate(vFXprefab, Target.transform.position + new Vector3(0, 2, 0), Quaternion.identity).transform.LookAt(Target.transform.position);
        }
    }
}
