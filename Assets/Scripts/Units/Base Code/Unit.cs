using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Listener
{
    public UnitType unitType;
    public string UnitName;

    [SerializeField] protected Ability[] vanguardAbilities = new Ability[3];
    public Ability[] VanguardAbilities => vanguardAbilities;
    [SerializeField] protected Ability[] supportAbilities =  new Ability[3];
    public Ability[] SupportAbilities => supportAbilities;

    [SerializeField] GameObject DamageNumbers;

    SpriteRenderer spriteRenderer;
    private Billboard billboard;
    private Animator animator;
    public Transform AmmoBar;
    public Transform ManaBar;

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
            if(value <= 0) 
            {
                GameEvents.Kill(this);
            }
        }
    }

    [SerializeField] private int maxAmmo;
    public int MaxAmmo
    {
        get => maxAmmo;
    }

    private int ammo;
    public int Ammo
    {
        get => ammo;
        set
        {
            ammo = value;
            UIEvents.UnitAmmoChanged(this, ammo, maxAmmo);
        }
    }

    [SerializeField] private int maxMana;
    public int MaxMana
    {
        get => maxMana;
    }

    private int mana;
    public int Mana
    {
        get => mana;
        set
        {
            mana = value;
            UIEvents.UnitManaChanged(this, mana);
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

    protected int thorns;
    public int Thorns
    {
        get => thorns;
        set
        {
            thorns = value;
            UIEvents.UnitThornsChanged(this, thorns);
        }
    }

    // End variables, Start Functions

    private void OnHealthChanged(Unit target, int healthChange)
    {
        if (target == this)
        {
            Health += healthChange;
            Instantiate(DamageNumbers, transform.position, Quaternion.identity).GetComponent<DamageNumbersController>().SetHealthChangeAmount(healthChange);

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

    private void OnThornsChanged(Unit target, int ThornsChange)
    {
        if (target == this)
        {
            Thorns += ThornsChange;
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
                if (targetAbility.IsAbilityValid(caster, target)) 
                {
                    targetAbility.UseAbility(this, target);
                    GameEvents.AbilityResolved(this);
                }
                else Debug.Log("Caster = " + caster + "\n" + "Target = " + target);
            }

        }
    }

    private void OnUseAmmo(Unit caster, int cost)
    {
        if (caster == this)
        {
            Ammo -= cost;
        }
    }

    private void OnUseMana(Unit caster, int cost)
    {
        if (caster == this)
        {
            Mana -= cost;
        }
    }

    private void OnAttacked(Unit Attacker, Unit Defender, int Damage)
    {
        if (Defender == this)
        {
            if (Thorns != 0)
            {
                GameEvents.HealthChanged(Attacker, -Thorns);
            }
        }
    }

    // Start is called before the first frame update
    public int GetStickScore()
    {
        return GetMoveScoreAIAlgorithm();
    }

    public int GetSwitchScore()
    {
        return GetMoveScoreAIAlgorithm();
    }

    public void SetupUnit(UnitType uType, string uName, AbilitySetup[] vAbilities, AbilitySetup[] sAbilities, int mHealth, int mAmmo, int mMana, RuntimeAnimatorController anim)
    {
        unitType = uType;

        switch (unitType)
        {
            case UnitType.Military:
                Destroy(ManaBar.gameObject);
                break;
            case UnitType.Mage:
                Destroy(AmmoBar.gameObject);
                break;
            case UnitType.Commander:
                AmmoBar.transform.position = Vector3.up * -1.5f;
                break;
            default:
                break;
        }

        UnitName = uName;
        for (int i = 1; i < vAbilities.Length; i++)
        {
            Type fuckyou = Type.GetType(vAbilities[i].AbilityType.ToString());
            Ability newAbility = gameObject.AddComponent(fuckyou) as Ability;
            newAbility.SetupParams(vAbilities[i]);
            vanguardAbilities[i-1] = newAbility;
        }
        for (int i = 1; i < sAbilities.Length; i++)
        {
            Type fuckyou = Type.GetType(sAbilities[i].AbilityType.ToString());
            Ability newAbility = gameObject.AddComponent(fuckyou) as Ability;
            newAbility.SetupParams(sAbilities[i]);
            supportAbilities[i-1] = newAbility;
        }
        maxHealth = mHealth;
        maxAmmo = mAmmo;
        maxMana = mMana;
        animator.runtimeAnimatorController = anim;

        ResetUnit();
    }
    protected virtual void ResetUnit()
    {
        Health = MaxHealth;
        Ammo = MaxAmmo;
        Mana = MaxMana;
        ResetBuffs();
    }
    protected virtual void ResetBuffs()
    {
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
        GameEvents.onThornsUp += OnThornsChanged;
        GameEvents.onUseAbility += UseAbility;
        GameEvents.onUseMana += OnUseMana;
        GameEvents.onUseAmmo += OnUseAmmo;
        GameEvents.resetBuffs += ResetBuffs;
        GameEvents.onUnitAttack += OnAttacked;

        GameEvents.onPhaseChanged += UpdateBillboard;
        
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onBattleStarted -= ResetUnit;
        GameEvents.onHealthChanged -= OnHealthChanged;
        GameEvents.onDefenseUp -= OnDefenseChanged;
        GameEvents.onAttackUp -= OnAttackChanged;
        GameEvents.onAccuracyUp -= OnAccuracyChanged;
        GameEvents.onThornsUp -= OnThornsChanged;
        GameEvents.onUseAbility -= UseAbility;
        GameEvents.onUseMana -= OnUseMana;
        GameEvents.onUseAmmo -= OnUseAmmo;
        GameEvents.resetBuffs -= ResetBuffs;
        GameEvents.onUnitAttack -= OnAttacked;

        GameEvents.onPhaseChanged -= UpdateBillboard;

    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        billboard = GetComponent<Billboard>();

        DamageNumbers = Resources.Load("UIPrefabs/DamageText") as GameObject;
    }
    void UpdateBillboard(RoundController.Phase _phase)
    {
        billboard.SwitchBillboardState(((int)_phase)>=2);
    }

    public void UpdateEnemyVisual()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(spriteRenderer)
        {
            spriteRenderer.color = new Color(0.85f, 0.66f, 1, 1);
            spriteRenderer.flipX = true;
        }
        
    }
}

public enum UnitType
{
    Mage, Military, Commander
}