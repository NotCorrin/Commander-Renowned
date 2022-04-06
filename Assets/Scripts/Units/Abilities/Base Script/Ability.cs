using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public abstract int GetMoveWeight();
    public abstract void UseAbility(Unit Caster, Unit Target);
}
