using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Ability
{
    [SerializeField] int Damage;
    [SerializeField] int Cost;

    public override int GetMoveWeight()
    {
        return 0;
    }

    public override void UseAbility(Unit Caster, Unit Target)
    {
        if (IsAbilityValid(Caster, Target))
        {
            GameEvents.AttackUp(Caster, 1);
            GameEvents.HealthChanged(Target, -GetDamageCalculation(Caster, Target, Damage));
            GameEvents.UseAmmo(Caster, Cost);
        }

    }

    public override bool IsAbilityValid(Unit Caster, Unit Target)
    {
        if (Caster is MilitaryUnit)
        {
            MilitaryUnit casterUnit = Caster as MilitaryUnit;
            return casterUnit.Ammo >= Cost;
        }
        else if (Caster is CommanderUnit)
        {
            CommanderUnit casterUnit = Caster as CommanderUnit;
            return casterUnit.Ammo >= Cost;
        }

        return false;
    }
}
