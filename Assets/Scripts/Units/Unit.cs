using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : ScriptableObject
{
    protected float health;
    protected bool isEnemy;
    protected bool isVanguard;
    protected float weight;

    public void Defend()
    {

    }

}
