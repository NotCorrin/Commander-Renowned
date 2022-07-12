using UnityEngine;

[System.Serializable]
public abstract class Ability : MonoBehaviour
{
    /// <summary>
    /// Gets or sets a value indicating whether or not ability has a variable cost.
    /// </summary>
    public bool XCost { get; set; }

    public bool IsMagic { get; protected set; }

    public string AbilityName { get; protected set; }

    public string AbilityDescription { get; protected set; }

    public int Cost { get; protected set; }

    public int Damage { get; protected set; }

    public int StatBoost { get; protected set; }

    public int Variation { get; protected set; }

    public TargetMode ForceTarget { get; set; }

    public Icon[] Buffs { get; set; }

    protected GameObject VFX1 { get; set; }

    protected GameObject VFX2 { get; set; }

    protected GameObject VFX3 { get; set; }

    public virtual void SetupParams(AbilitySetup setup)
    {
        AbilityName = setup.AbilityName;
        AbilityDescription = setup.AbilityDescription;
        Cost = setup.Cost;
        if (setup.Cost == 999)
        {
            XCost = true;
            Cost = 0;
        }

        ForceTarget = setup.ForceTarget;
        Damage = setup.Damage;
        StatBoost = setup.StatBoost;
        Variation = setup.Variation;
        VFX1 = setup.VFX1;
        VFX2 = setup.VFX2;
        VFX3 = setup.VFX3;
    }

    public abstract int GetMoveWeight(Unit caster);

    public abstract void UseAbility(Unit caster, Unit target);

    public virtual bool IsAbilityValid(Unit caster, Unit target)
    {
        return IsCasterValid(caster) && IsTargetValid(target, FieldController.Main.IsUnitPlayer(caster)) && caster && target;
    }

    public abstract bool IsCasterValid(Unit caster);

    public abstract bool IsTargetValid(Unit target, bool isPlayer);

    protected int GetDamageCalculation(Unit caster, Unit target, int damage)
    {
        return Mathf.Max(damage + caster.BonusDamage - target.BonusDefense, 0);
    }

    protected int GetTotalDamageBuffs(Unit caster)
    {
        int totalDamageBuffs = 0;
        totalDamageBuffs += caster.BonusDamage;
        /*Version made AI look at opponent defense buffs. Took away satisfaction of oursmarting AI
        totalDamageBuffs -= FieldController.main.GetUnit(FieldController.Position.Vanguard, !FieldController.main.IsUnitPlayer(Caster)).Defense);*/
        return totalDamageBuffs;
    }

    protected int GetTotalDefenseBuffs(Unit caster)
    {
        int totalDefenseBuffs = 0;
        totalDefenseBuffs += caster.BonusDefense;
        /*Version made AI look at opponent defense buffs. Took away satisfaction of oursmarting AI
        totalDamageBuffs -= FieldController.main.GetUnit(FieldController.Position.Vanguard, !FieldController.main.IsUnitPlayer(Caster)).Defense);*/
        return totalDefenseBuffs;
    }
}