using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MilitaryUnit : Unit
{
    protected float ammunition;
    protected float maxAmmunition;

    public void Attack()
    {
        if (ammunition > 0 && isVanguard)
        {
            //deal damage to enemy vanguard
            //subtract an ammunition value, fixed for all units?
        }
    }

    private void Reload()
    {
        if (!isVanguard)
        {
            ammunition = maxAmmunition;
        }
    }
    public abstract void Ability();

}
