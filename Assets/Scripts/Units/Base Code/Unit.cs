using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : Listener
{
    [SerializeField] Ability[] VanguardAbilities = new Ability[3];
    [SerializeField] Ability[] SupportAbilities =  new Ability[3];

    [SerializeField] protected int maxHealth;
    
    public enum AbilityNumber { One, Two, Three};
    public int MaxHealth
    {
        get => maxHealth;
    }

    protected int health;
    public int Health
    {
        get => health;
        set
        {
            health = value;
            ScoreEvents.UnitHealthChanged(this, health);
        }
    }

    protected int attack;
    public int Attack
    {
        get => attack;
        set
        {
            attack = value;
            ScoreEvents.UnitAttackChanged(this, attack);
        }
    }

    protected int defense;
    public int Defense
    {
        get => defense;
        set
        {
            defense = value;
            ScoreEvents.UnitDefenseChanged(this, defense);
        }
    }

    // Start is called before the first frame update
    public abstract int GetStickScore();

    public abstract int GetSwitchScore();

    protected override void SubscribeListeners()
    {
        throw new System.NotImplementedException();
    }

    protected override void UnsubscribeListeners()
    {
        throw new System.NotImplementedException();
    }
}