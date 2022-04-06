using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : Listener
{
    [SerializeField] Ability[] VanguardAbilities = new Ability[3];
    [SerializeField] Ability[] SupportAbilities =  new Ability[3];

    [SerializeField] protected int maxHealth;

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

    protected void UseAbility(Unit caster, Unit target, int selectedAbility)
    {
        if (caster == this)
        {
            if (FieldController.main.GetPosition(this) == FieldController.Position.Vanguard)
            {
                Ability targetAbility = VanguardAbilities[selectedAbility - 1];
                if (targetAbility.IsAbilityValid(caster)) targetAbility.UseAbility(this, target);
                else Debug.Log("Ability Can't be Used");
            }
            else
            {
                Ability targetAbility = SupportAbilities[selectedAbility - 1];
                if (targetAbility.IsAbilityValid(caster)) targetAbility.UseAbility(this, target);
                else Debug.Log("Ability Can't be Used");
            }
        }
    }

    // Start is called before the first frame update
    public abstract int GetStickScore();

    public abstract int GetSwitchScore();

    protected virtual void ResetUnit()
    {
        Health = MaxHealth;
    }

    private void OnHeathChanged(Unit target, int healthChange)
    {
        if (target == this)
        {
            Health += healthChange;
        }
    }

    protected override void SubscribeListeners()
    {
        GameEvents.onBattleStarted += ResetUnit;
        GameEvents.onHealthChanged += OnHeathChanged;
        
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onBattleStarted -= ResetUnit;
        GameEvents.onHealthChanged -= OnHeathChanged;
    }
}
