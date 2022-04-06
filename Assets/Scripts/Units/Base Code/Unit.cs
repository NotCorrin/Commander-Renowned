using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : Listener
{
    [SerializeField] Ability[] VanguardAbilities = new Ability[3];
    [SerializeField] Ability[] SupportAbilities =  new Ability[3];

    SpriteRenderer spriteRenderer;
    Animator animator;

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

    // End variables, Start Functions

    private void OnHealthChanged(Unit target, int healthChange)
    {
        if (target == this)
        {
            Health += healthChange;
        }
    }

    private void OnAttackChanged(Unit target, int AttackChange)
    {
        if (target == this)
        {
            Attack += AttackChange;
        }
    }

    private void OnDefenseChanged(Unit target, int DefenseChange)
    {
        if (target == this)
        {
            Defense += DefenseChange;
        }
    }

    protected void UseAbility(Unit caster, Unit target, int selectedAbility)
    {
        if (caster == this)
        {
            Ability targetAbility;

            if (FieldController.main.GetPosition(this) == FieldController.Position.Vanguard)
            {
                targetAbility = VanguardAbilities[selectedAbility - 1];
            }
            else
            {
                targetAbility = SupportAbilities[selectedAbility - 1];
            }

            if (targetAbility != null)
            {
                if (targetAbility.IsAbilityValid(caster, target)) targetAbility.UseAbility(this, target);
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



    protected override void SubscribeListeners()
    {
        GameEvents.onBattleStarted += ResetUnit;
        GameEvents.onHealthChanged += OnHealthChanged;
        GameEvents.onDefenceUp += OnDefenseChanged;
        GameEvents.onAttackUp += OnAttackChanged;
        
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onBattleStarted -= ResetUnit;
        GameEvents.onHealthChanged -= OnHealthChanged;
        GameEvents.onDefenceUp -= OnDefenseChanged;
        GameEvents.onAttackUp -= OnAttackChanged;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
