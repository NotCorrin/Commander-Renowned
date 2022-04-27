using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : Listener
{
    [SerializeField] protected Ability[] vanguardAbilities = new Ability[3];
    public Ability[] VanguardAbilities => vanguardAbilities;
    [SerializeField] protected Ability[] supportAbilities =  new Ability[3];
    public Ability[] SupportAbilities => supportAbilities;


    SpriteRenderer spriteRenderer;
    Animator animator;

    [SerializeField] protected int maxHealth;

    public int MaxHealth
    {
        get => maxHealth;
    }

    [SerializeField]
    protected int health;
    public int Health
    {
        get => health;
        set
        {
            health = value;
            UIEvents.UnitHealthChanged(this, health);
        }
    }

    protected int attack;
    public int Attack
    {
        get => attack;
        set
        {
            attack = value;
            UIEvents.UnitAttackChanged(this, attack);
        }
    }

    protected int defense;
    public int Defense
    {
        get => defense;
        set
        {
            defense = value;
            UIEvents.UnitDefenseChanged(this, defense);
        }
    }

    protected int accuracy;
    public int Accuracy
    {
        get => accuracy;
        set
        {
            accuracy = value;
            UIEvents.UnitAccuracyChanged(this, accuracy);
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

    private void OnAccuracyChanged(Unit target, int AccuracyChange)
    {
        if (target == this)
        {
            Accuracy += AccuracyChange;
        }
    }

    protected void UseAbility(Unit caster, Unit target, int selectedAbility)
    {
        if (caster == this)
        {
            Ability targetAbility;
            if (FieldController.main.GetPosition(this) == FieldController.Position.Vanguard)
            {
                targetAbility = vanguardAbilities[selectedAbility - 1];
            }
            else
            {
                targetAbility = supportAbilities[selectedAbility - 1];
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
        Attack = 0;
        Defense = 0;
        Accuracy = 0;
    }

    protected int GetMoveScoreAIAlgorithm()
    {
        int totalVanguardMoveScore = 0;
        int totalVanguardMoves = 0;
        foreach (Ability ability in vanguardAbilities)
        {
            if (ability)
            {
                totalVanguardMoves++;
                totalVanguardMoveScore += ability.GetMoveWeight(this);
            }
        }

        int totalSupportMoveScore = 0;
        int totalSupportMoves = 0;
        foreach (Ability ability in supportAbilities)
        {
            if (ability)
            {
                totalSupportMoves++;
                totalSupportMoveScore += ability.GetMoveWeight(this);
            }
        }

        return (totalVanguardMoveScore / totalVanguardMoves) - (totalSupportMoveScore / totalSupportMoves);
    }



    protected override void SubscribeListeners()
    {
        GameEvents.onBattleStarted += ResetUnit;
        GameEvents.onHealthChanged += OnHealthChanged;
        GameEvents.onDefenseUp += OnDefenseChanged;
        GameEvents.onAttackUp += OnAttackChanged;
        GameEvents.onAccuracyUp += OnAccuracyChanged;
        GameEvents.onUseAbility += UseAbility;

        
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onBattleStarted -= ResetUnit;
        GameEvents.onHealthChanged -= OnHealthChanged;
        GameEvents.onDefenseUp -= OnDefenseChanged;
        GameEvents.onAttackUp -= OnAttackChanged;
        GameEvents.onAccuracyUp -= OnAccuracyChanged;
        GameEvents.onUseAbility -= UseAbility;

    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
