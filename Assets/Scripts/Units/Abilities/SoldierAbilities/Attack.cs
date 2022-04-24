using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : QTEAbility
{
    [SerializeField] int Damage;
    [SerializeField] int Cost;

    [SerializeField] int DamageVariation;

    public override int GetMoveWeight(Unit caster)
    {
        return 0;
    }

    protected override void AbilityUsed(QTEController.QTEResult result)
    {
        int FinalDamage = Damage;

        switch (result)
        {
            case QTEController.QTEResult.Critical:
                {
                    FinalDamage += DamageVariation;
                    break;
                }
            case QTEController.QTEResult.Miss:
                {
                    FinalDamage -= DamageVariation;
                    break;
                }
        }
        

        GameEvents.AttackUp(Caster, 1);
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
