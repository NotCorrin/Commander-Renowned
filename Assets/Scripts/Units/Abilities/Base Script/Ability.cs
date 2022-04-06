using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public abstract int GetMoveWeight();
    public abstract void UseAbility(Unit Caster, Unit Target);
    public abstract bool IsAbilityValid(Unit Caster);
}
