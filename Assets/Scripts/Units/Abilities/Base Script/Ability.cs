using UnityEngine;

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

    public abstract int GetMoveWeight(Unit Caster);
    public abstract void UseAbility(Unit Caster, Unit Target);
    public abstract bool IsAbilityValid(Unit Caster, Unit Target);
    protected int GetDamageCalculation(Unit Caster, Unit Target, int Damage)
    {
        return Mathf.Max(Damage + Caster.Attack - Target.Defense, 0);
    }
}
