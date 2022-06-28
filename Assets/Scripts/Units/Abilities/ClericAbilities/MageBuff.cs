using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBuff : Ability
{
    public override void SetupParams(AbilitySetup setup)
    {
        base.SetupParams(setup);
        if (!VFX1)
        {
            VFX1 = Resources.Load("CustomLasers/Mage/BuffParticles") as GameObject;
        }

        IsMagic = true;

        // buffs.add(new Buff(BuffType.Attack))
    }

    public override bool IsCasterValid(Unit caster)
    {
        return caster.Mana >= Cost;
    }

    public override bool IsTargetValid(Unit target, bool isPlayer)
    {
        if (isPlayer)
        {
            return FieldController.Main.IsUnitPlayer(target);
        }
        else
        {
            return (FieldController.Main.GetPosition(target) == FieldController.Position.Vanguard) && (FieldController.Main.IsUnitPlayer(target) == isPlayer) && target;
        }
    }

    public override void UseAbility(Unit caster, Unit target)
    {
        if (IsAbilityValid(caster, target))
        {
            Instantiate(VFX1, target.transform);
            GameEvents.AttackUp(target, StatBoost);
            GameEvents.UseMana(caster, Cost);
        }
    }

    /// <summary>
    /// Returns weight of move, used in deciding move priority.
    /// </summary>
    /// <param name="caster">
    /// The unit casting the ability.
    /// </param>
    /// <returns>
    /// The weight of the move given a caster.
    /// </returns>
    public override int GetMoveWeight(Unit caster)
    {
        int healthWeight = Mathf.FloorToInt((1 - ((float)caster.Health / (float)caster.MaxHealth)) * 100);
        int manaWeight;

        if (caster.UnitType == UnitType.Mage || caster.UnitType == UnitType.Commander)
        {
            if (caster.Mana < Cost)
            {
                return 0;
            }

            manaWeight = Mathf.FloorToInt(((float)caster.Mana / (float)caster.MaxMana) * 100);
        }
        else
        {
            return 0;
        }

        return (healthWeight + (2 * manaWeight)) / 3;
    }
}
