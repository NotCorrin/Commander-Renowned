using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] string AbilityName;
    [SerializeField] string AbilityDescription;
    public abstract int GetMoveWeight();
    public abstract void UseAbility(Unit Caster, Unit Target);
    public abstract bool IsAbilityValid(Unit Caster, Unit Target);
    protected int GetDamageCalculation(Unit Caster, Unit Target, int Damage)
    {
        return Mathf.Max(Damage + Caster.Attack - Target.Defense, 0);
    }
}
