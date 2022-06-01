using UnityEngine;

[System.Serializable]
public abstract class Ability : MonoBehaviour
{
    protected bool isMagic;
    public bool IsMagic
    {
        get => isMagic;
    }
    [SerializeField] protected string abilityName;
    public string AbilityName
    {
        get => abilityName;
    }

    [SerializeField] protected string abilityDescription;
    public string AbilityDescription
    {
        get => abilityDescription;
    }

    [SerializeField] protected int cost;
    public int Cost
    {
        get => cost;
    }
    public bool xCost;

    [SerializeField] protected int damage;
    public int Damage
    {
        get => damage;
    }

    [SerializeField] protected int statBoost;
    public int StatBoost
    {
        get => statBoost;
    }

    [SerializeField] protected int variation;
    public int Variation
    {
        get => variation;
    }

    public TargetMode forceTarget;

    public Icon[] buffs;
    [SerializeField] protected GameObject VFX1;
    [SerializeField] protected GameObject VFX2;
    [SerializeField] protected GameObject VFX3;


    public virtual void SetupParams(AbilitySetup setup)
    {
        abilityName = setup.AbilityName;
        abilityDescription = setup.AbilityDescription;
        cost = setup.Cost;
        if (setup.Cost == 999)
        {
            xCost = true;
            cost = 0;
        }
        forceTarget = setup.ForceTarget;
        damage = setup.Damage;
        statBoost = setup.StatBoost;
        variation = setup.Variation;
        VFX1 = setup.VFX1;
        VFX2 = setup.VFX2;
        VFX3 = setup.VFX3;
    }
    public abstract int GetMoveWeight(Unit Caster);
    public abstract void UseAbility(Unit Caster, Unit Target);
    public virtual bool IsAbilityValid(Unit Caster, Unit Target) 
    {
        return IsCasterValid(Caster) && IsTargetValid(Target, FieldController.main.IsUnitPlayer(Caster));
    }
    public abstract bool IsCasterValid(Unit Caster);
    public abstract bool IsTargetValid(Unit Target, bool isPlayer);
    protected int GetDamageCalculation(Unit Caster, Unit Target, int Damage)
    {
        return Mathf.Max(Damage + Caster.Attack - Target.Defense, 0);
    }

    protected int GetTotalDamageBuffs(Unit Caster)
    {
        int totalDamageBuffs = 0;
        totalDamageBuffs += Caster.Attack;
        /*Version made AI look at opponent defense buffs. Took away satisfaction of oursmarting AI
        totalDamageBuffs -= FieldController.main.GetUnit(FieldController.Position.Vanguard, !FieldController.main.IsUnitPlayer(Caster)).Defense);*/
        return totalDamageBuffs;
    }

    protected int GetTotalDefenseBuffs(Unit Caster)
    {
        int totalDefenseBuffs = 0;
        totalDefenseBuffs += Caster.Defense;
        /*Version made AI look at opponent defense buffs. Took away satisfaction of oursmarting AI
        totalDamageBuffs -= FieldController.main.GetUnit(FieldController.Position.Vanguard, !FieldController.main.IsUnitPlayer(Caster)).Defense);*/
        return totalDefenseBuffs;
    }
}

[System.Serializable]
public struct Icon
{
    public IconType iconType;
    public int buffAmount;

    public Icon(IconType t, int a)
    {
        iconType = t;
        buffAmount = a;
    }
}

public enum IconType
{
    Attack,
    Defence
}

public enum TargetMode
{
    Default,
    True,
    False
}