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

    [SerializeField] SpriteRenderer spriteRenderer;
    Collider coll;
    [SerializeField] private Billboard billboard;
    [SerializeField] private Animator animator;
    public Transform HealthBar;
    public Transform AmmoBar;
    public Transform ManaBar;
    public Transform BuffBar;


    public GameObject visibleElements;

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
            health = Mathf.Clamp(value, 0, MaxHealth);
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
            ammo = Mathf.Clamp(value, 0, MaxAmmo);
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
            mana = Mathf.Clamp(value, 0, MaxMana);
            UIEvents.UnitManaChanged(this, mana, MaxMana);
        }
    }

    protected int baseAttack;
        //[SerializeField]

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

    protected int baseDefense;
    protected int defense;
    public int Defense {
        get => defense;
        set {
            defense = value;
            UIEvents.UnitDefenseChanged(this, defense);
        }
    }

    protected int baseAccuracy;
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
    private void OnBaseAttackChanged(Unit target, int AttackChange)
    {
        if (target == this)
        {
            baseAttack += AttackChange;
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
    private void OnBaseDefenseChanged(Unit target, int DefenseChange)
    {
        if (target == this)
        {
            baseDefense += DefenseChange;
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

    void GreyOut(Ability ability, bool isPlayer)
    {
        if(!ability)
        {
            Debug.Log(spriteRenderer.color);
            if(!FieldController.main.IsUnitPlayer(this)) UpdateEnemyVisual();
            else spriteRenderer.color = Color.white;
        }
        else if(!ability.IsTargetValid(this, isPlayer))
        {
            spriteRenderer.color -= new Color(0.5f,0.5f,0.5f,0.2f);
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
        if(!FieldController.main.IsUnitPlayer(this)) UpdateEnemyVisual();
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

    private void OnKill(Unit unit)
    {
        if (unit == this)
        {
            animator.SetTrigger("killUnit");
            if (GetComponent<SphereCollider>()) Destroy(GetComponent<SphereCollider>());
        }
    }

    private void KillUnit()
    {
        if (visibleElements) Destroy(visibleElements);

        if (HealthBar) Destroy(HealthBar.gameObject);
        if (ManaBar) Destroy(ManaBar.gameObject);
        if (AmmoBar) Destroy(AmmoBar.gameObject);
        if(BuffBar) Destroy(BuffBar.gameObject);
        spriteRenderer.sprite = null;
        if (animator) Destroy(animator);

    }

    // Start is called before the first frame update
    public int GetStickScore()
    {
        return GetStandardAlgorithm();
    }

    public int GetSwitchScore()
    {
        return GetStandardAlgorithm();
    }

    public void SetupUnit(UnitType uType, string uName, AbilitySetup[] vAbilities, AbilitySetup[] sAbilities, int mHealth, int mAmmo, int mMana, RuntimeAnimatorController anim, Sprite sprite)
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
                AmmoBar.transform.position += Vector3.up * -0.65f;
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
        spriteRenderer.sprite = sprite;
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
        if(RoundController.isPlayerPhase == FieldController.main.IsUnitPlayer(this))
        {
            baseAttack = Mathf.Max(0, --baseAttack);
            baseAccuracy = Mathf.Max(0, --baseAccuracy);
            Attack = baseAttack;
            Accuracy = baseAccuracy;
        }
        else
        {
            baseDefense = Mathf.Max(0, --baseDefense);
            Defense = baseDefense;
        }
    }

    protected int GetStandardAlgorithm()
    {
        int finalWeight;

        int moveWeight = 0;
        int healthWeight = 0;
        int buffWeight = 0;
        int resourceWeight = 0;

        int totalVanguardMoveScore = 0;
        int totalVanguardMoves = 0;

        foreach (Ability ability in vanguardAbilities)
        {
            if (ability)
            {
                if (ability.GetMoveWeight(this) > totalVanguardMoveScore)
                {
                    totalVanguardMoveScore = ability.GetMoveWeight(this);
                }
            }
        }

        if (totalVanguardMoves == 0) totalVanguardMoves = -100; 

        int totalSupportMoveScore = 0;
        int totalSupportMoves = 0;
        foreach (Ability ability in supportAbilities)
        {
            if (ability)
            {
                if (ability.GetMoveWeight(this) > totalSupportMoveScore)
                {
                    totalSupportMoveScore = ability.GetMoveWeight(this);
                }
            }
        }

        if (totalSupportMoveScore > totalVanguardMoveScore)
        {
            moveWeight = -totalSupportMoveScore;
        }
        else
        {
            moveWeight = totalVanguardMoveScore;
        }

        healthWeight = Mathf.RoundToInt(((float)Health / (float)MaxHealth) * 100);

        if ((Attack + Defense + Thorns) > 0) buffWeight = 10;
        buffWeight += (Attack + Defense + Thorns) * 20 + Accuracy * 10;

        if (unitType == UnitType.Military || unitType == UnitType.Commander)
        {
            resourceWeight += Mathf.RoundToInt(100 * ((float)Ammo / (float)MaxAmmo));
        }

        if (unitType == UnitType.Mage || unitType == UnitType.Commander)
        {
            resourceWeight += Mathf.RoundToInt(100 * (1 - ((float)Mana / (float)MaxMana)));
        }

        if (unitType == UnitType.Commander)
        {
            resourceWeight = resourceWeight / 2;
        }

        finalWeight = (2 * moveWeight + healthWeight + resourceWeight) / 4 + buffWeight;
        Debug.Log(UnitName
        + "\n" + " final weight = " + finalWeight
        + "\n" + " move weight = " + moveWeight
        + "\n" + "health weight = " + healthWeight
        + "\n" + "resource weight = " + resourceWeight
        + "\n" + " weight - buffweight = " + ((2 * moveWeight + healthWeight + resourceWeight) / 4)
        + "\n" + "buffweight = " + buffWeight
        );

        return finalWeight;
    }



    protected override void SubscribeListeners()
    {
        GameEvents.onBattleStarted += ResetUnit;
        GameEvents.onHealthChanged += OnHealthChanged;
        GameEvents.onDefenseUp += OnDefenseChanged;
        GameEvents.onBaseDefenseUp += OnBaseDefenseChanged;
        GameEvents.onAttackUp += OnAttackChanged;
        GameEvents.onBaseAttackUp += OnBaseAttackChanged;
        GameEvents.onAccuracyUp += OnAccuracyChanged;
        GameEvents.onThornsUp += OnThornsChanged;
        GameEvents.onUseAbility += UseAbility;
        GameEvents.onUseMana += OnUseMana;
        GameEvents.onUseAmmo += OnUseAmmo;
        GameEvents.onResetBuffs += ResetBuffs;
        GameEvents.onUnitAttack += OnAttacked;
        GameEvents.onKill += OnKill;

        GameEvents.onPhaseChanged += UpdateBillboard;
        GameEvents.onGreyOut += GreyOut;
        
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onBattleStarted -= ResetUnit;
        GameEvents.onHealthChanged -= OnHealthChanged;
        GameEvents.onDefenseUp -= OnDefenseChanged;
        GameEvents.onBaseDefenseUp -= OnBaseDefenseChanged;
        GameEvents.onAttackUp -= OnAttackChanged;
        GameEvents.onBaseAttackUp -= OnBaseAttackChanged;
        GameEvents.onAccuracyUp -= OnAccuracyChanged;
        GameEvents.onThornsUp -= OnThornsChanged;
        GameEvents.onUseAbility -= UseAbility;
        GameEvents.onUseMana -= OnUseMana;
        GameEvents.onUseAmmo -= OnUseAmmo;
        GameEvents.onResetBuffs -= ResetBuffs;
        GameEvents.onUnitAttack -= OnAttacked;
        GameEvents.onKill += OnKill;

        GameEvents.onPhaseChanged -= UpdateBillboard;

    }

    private void Awake()
    {
        if (!animator) animator = GetComponent<Animator>();
        if (!billboard) billboard = GetComponent<Billboard>();
        if (!coll) coll = GetComponent<Collider>();
        if (!spriteRenderer) spriteRenderer = GetComponent<SpriteRenderer>();

        if (!DamageNumbers) DamageNumbers = Resources.Load("UIPrefabs/DamageText") as GameObject;
    }
    void UpdateBillboard(RoundController.Phase _phase)
    {
        billboard.SwitchBillboardState(((int)_phase)>=2);
    }

    public void UpdateEnemyVisual()
    {
        if(spriteRenderer)
        {
            spriteRenderer.color = new Color(0.85f, 0.66f, 1, 1);
            //spriteRenderer.color = Color.black;
            spriteRenderer.flipX = true;
        }
    }
}

public enum UnitType
{
    Mage, Military, Commander
}