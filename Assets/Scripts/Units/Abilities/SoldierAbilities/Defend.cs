using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : QTEAbility
{
    [SerializeField] int Damage;
    [SerializeField] int DefenseBoost;

    [SerializeField] int DefenseVariation;

    public override int GetMoveWeight(Unit caster)
    {
        int HealthWeight = Mathf.FloorToInt(1 - (caster.Health / caster.MaxHealth) * 100);
        int AmmoWeight;

        if (caster is MilitaryUnit)
        {
            MilitaryUnit militaryCaster = caster as MilitaryUnit;

            if (militaryCaster.Ammo < Cost) return 0;

            AmmoWeight = Mathf.FloorToInt((militaryCaster.Ammo / militaryCaster.MaxAmmo) * 100);

        }
        else if (caster is CommanderUnit)
        {
            CommanderUnit commanderCaster = caster as CommanderUnit;
            if (commanderCaster.Ammo < Cost) return 0;

            AmmoWeight = Mathf.FloorToInt((commanderCaster.Ammo / commanderCaster.MaxAmmo) * 100);

        }

        else return 0;

        return (2 * HealthWeight + AmmoWeight) / 3;
    }

    protected override void AbilityUsed(QTEController.QTEResult result)
    {
        int FinalDefense = DefenseBoost;

        switch (result)
        {
            case QTEController.QTEResult.Critical:
                {
                    FinalDefense += DefenseVariation;
                    break;
                }
            case QTEController.QTEResult.Miss:
                {
                    FinalDefense = Mathf.Max(0, FinalDefense - DefenseVariation);
                    break;
                }
        }

        GameEvents.DefenseUp(Caster, DefenseBoost);
        GameEvents.HealthChanged(Target, -GetDamageCalculation(Caster, Target, Damage));
        GameEvents.UseAmmo(Caster, Cost);
    }

    protected override QTEController.QTEType GetQTEType()
    {
        return QTEController.QTEType.shrinkingCircle;
    }

    public override bool IsAbilityValid(Unit Caster, Unit Target)
    {
        bool casterValid;
        bool targetValid;

        if (Caster is MilitaryUnit)
        {
            MilitaryUnit casterUnit = Caster as MilitaryUnit;
            casterValid = casterUnit.Ammo >= Cost;
        }
        else if (Caster is CommanderUnit)
        {
            CommanderUnit casterUnit = Caster as CommanderUnit;
            casterValid = casterUnit.Ammo >= Cost;
        }
        else return false;

        targetValid = (FieldController.main.GetPosition(Target) == FieldController.Position.Vanguard) && !FieldController.main.IsUnitPlayer(Target);

        return casterValid && targetValid;
    }
}
