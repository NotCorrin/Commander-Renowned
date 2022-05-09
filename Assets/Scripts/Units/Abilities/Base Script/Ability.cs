using UnityEngine;

[System.Serializable]
public abstract class Ability : MonoBehaviour
{
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
    public virtual void SetupParams(AbilitySetup setup)
    {
        abilityName = setup.AbilityName;
        abilityDescription = setup.AbilityDescription;
        cost = setup.Cost;
        damage = setup.Damage;
        statBoost = setup.StatBoost;
        variation = setup.Variation;
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
}
