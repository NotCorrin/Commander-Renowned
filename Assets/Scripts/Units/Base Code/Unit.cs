using System;
using UnityEngine;

public class Unit : Listener
{
    [SerializeField] private GameObject damageNumbers;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private Collider coll;

    [SerializeField] private GameObject visibleElements;

    [SerializeField] private Billboard billboard;

    [SerializeField] private Animator animator;

    [SerializeField] private Transform healthBar;

    [SerializeField] private Transform ammoBar;

    [SerializeField] private Transform manaBar;

    [SerializeField] private Transform buffBar;

    [SerializeField] private ParticleSystem ps;

    [SerializeField] private ParticleSystem selectedps;

    public UnitType UnitType { get; set; }

    public string UnitName { get; set; }

    public Ability[] VanguardAbilities { get; private set; } = new Ability[3];

    public Ability[] SupportAbilities { get; private set; } = new Ability[3];

    public int MaxHealth { get; private set; }

#pragma warning disable SA1201 // Elements should appear in the correct order. Done here for grouping purposes.
    private int health;

    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, MaxHealth);
            UIEvents.UnitHealthChanged(this, health);
            if (value <= 0)
            {
                GameEvents.Kill(this);
            }
        }
    }

    public int MaxAmmo { get; private set; }

    private int ammo;

    public int Ammo
    {
        get => ammo;
        set
        {
            ammo = Mathf.Clamp(value, 0, MaxAmmo);
            UIEvents.UnitAmmoChanged(this, ammo, MaxAmmo);
        }
    }

    private int maxMana;

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

    private int permAttack;

    public int PermAttack
    {
        get => permAttack;
        set
        {
            permAttack = value;
            UIEvents.UnitPermAttackChanged(this, permAttack);
        }
    }

    private int attack;

    public int Attack
    {
        get => attack;
        set
        {
            attack = value;
            UIEvents.UnitAttackChanged(this, attack - permAttack);
        }
    }

    private int permDefense;

    public int PermDefense
    {
        get => permDefense;
        set
        {
            permDefense = value;
            UIEvents.UnitPermDefenseChanged(this, permDefense);
        }
    }

    private int defense;

    public int Defense
    {
        get => defense;
        set
        {
            defense = value;
            UIEvents.UnitDefenseChanged(this, defense - permDefense);
        }
    }

    private int accuracy;

    public int Accuracy
    {
        get => accuracy;
        set
        {
            accuracy = value;
            UIEvents.UnitAccuracyChanged(this, accuracy);
        }
    }

    private int thorns;

    public int Thorns
    {
        get => thorns;
        set
        {
            thorns = value;
            UIEvents.UnitThornsChanged(this, thorns);
        }
    }

#pragma warning restore SA1201 // Elements should appear in the correct order

    // End variables, Start Functions
    public int GetStickScore()
    {
        return GetStandardAlgorithm();
    }

    public int GetSwitchScore()
    {
        return GetStandardAlgorithm();
    }

    public void AbilityUsable()
    {
        if (selectedps)
        {
            if (!selectedps.isPlaying)
            {
                selectedps.Play();
            }

            var em = selectedps.emission;
            em.enabled = true;
        }
    }

    public void UpdateEnemyVisual()
    {
        /*if(spriteRenderer)
        //{
        //    spriteRenderer.color = new Color(0.85f, 0.66f, 1, 1);
        //    //spriteRenderer.color = Color.black;
        //    spriteRenderer.flipX = true;
        }*/
        animator.SetBool("enemy", true);
        spriteRenderer.flipX = true;
        if (ps)
        {
            if (!ps.isPlaying)
            {
                ps.Play();
            }
        }
    }

    public void SetupUnit(UnitType uType, string uName, AbilitySetup[] vAbilities, AbilitySetup[] sAbilities, int mHealth, int mAmmo, int mMana, RuntimeAnimatorController anim, Sprite sprite)
    {
        UnitType = uType;

        switch (UnitType)
        {
            case UnitType.Military:
                Destroy(manaBar.gameObject);
                break;
            case UnitType.Mage:
                Destroy(ammoBar.gameObject);
                break;
            case UnitType.Commander:
                ammoBar.transform.position += Vector3.up * -0.65f;
                break;
            default:
                break;
        }

        UnitName = uName;
        for (int i = 1; i < vAbilities.Length; i++)
        {
            Type abilityType = Type.GetType(vAbilities[i].AbilityType.ToString());
            Ability newAbility = gameObject.AddComponent(abilityType) as Ability;
            newAbility.SetupParams(vAbilities[i]);
            VanguardAbilities[i - 1] = newAbility;
        }

        for (int i = 1; i < sAbilities.Length; i++)
        {
            Type abilityType = Type.GetType(sAbilities[i].AbilityType.ToString());
            Ability newAbility = gameObject.AddComponent(abilityType) as Ability;
            newAbility.SetupParams(sAbilities[i]);
            SupportAbilities[i - 1] = newAbility;
        }

        MaxHealth = mHealth;
        MaxAmmo = mAmmo;
        maxMana = mMana;
        spriteRenderer.sprite = sprite;
        animator.runtimeAnimatorController = anim;

        ResetUnit();
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

        GameEvents.onAbilityResolved += AbilityDone;
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
        GameEvents.onGreyOut -= GreyOut;

        GameEvents.onAbilityResolved -= AbilityDone;
    }

    private void OnHealthChanged(Unit target, int healthChange)
    {
        if (target == this)
        {
            Health += healthChange;
            Instantiate(damageNumbers, transform.position, Quaternion.identity).GetComponent<DamageNumbersController>().SetHealthChangeAmount(healthChange);
        }
    }

    private void OnAttackChanged(Unit target, int attackChange)
    {
        if (target == this)
        {
            Attack += attackChange;
        }
    }

    private void OnBaseAttackChanged(Unit target, int attackChange)
    {
        if (target == this)
        {
            PermAttack += attackChange;
            Attack += attackChange;
        }
    }

    private void OnDefenseChanged(Unit target, int defenseChange)
    {
        if (target == this)
        {
            Defense += defenseChange;
        }
    }

    private void OnBaseDefenseChanged(Unit target, int defenseChange)
    {
        if (target == this)
        {
            PermDefense += defenseChange;
            Defense += defenseChange;
        }
    }

    private void OnAccuracyChanged(Unit target, int accuracyChange)
    {
        if (target == this)
        {
            Accuracy += accuracyChange;
        }
    }

    private void OnThornsChanged(Unit target, int thornsChange)
    {
        if (target == this)
        {
            Thorns += thornsChange;
        }
    }

    private void GreyOut(Ability ability, bool isPlayer)
    {
        Debug.LogWarning(this);
        if (!ability)
        {
            animator.SetBool("greyedOut", false);
            if (!FieldController.Main.IsUnitPlayer(this))
            {
                UpdateEnemyVisual();
            }
        }
        else if (!ability.IsTargetValid(this, isPlayer))
        {
            // spriteRenderer.color -= new Color(0.5f,0.5f,0.5f,0.2f);
            animator.SetBool("greyedOut", true);
        }
    }

    private void UseAbility(Unit caster, Unit target, int selectedAbility)
    {
        if (caster == this)
        {
            Ability targetAbility;
            if (FieldController.Main.GetPosition(this) == FieldController.Position.Vanguard)
            {
                targetAbility = VanguardAbilities[selectedAbility - 1];
            }
            else
            {
                targetAbility = SupportAbilities[selectedAbility - 1];
            }

            if (targetAbility != null)
            {
                if (targetAbility.IsAbilityValid(caster, target))
                {
                    targetAbility.UseAbility(this, target);
                    GameEvents.AbilityResolved(this);
                }
                else
                {
                    Debug.Log("Caster = " + caster + "\n" + "Target = " + target);
                }
            }
        }

        if (!FieldController.Main.IsUnitPlayer(this))
        {
            UpdateEnemyVisual();
        }

        if (!FieldController.Main.IsUnitPlayer(this))
        {
            UpdateEnemyVisual();
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

    private void OnAttacked(Unit attacker, Unit defender, int damage)
    {
        if (defender == this)
        {
            if (Thorns != 0)
            {
                GameEvents.HealthChanged(attacker, -Thorns);
            }
        }
    }

    private void OnKill(Unit unit)
    {
        if (unit == this)
        {
            animator.SetTrigger("killUnit");
            if (GetComponent<SphereCollider>())
            {
                Destroy(GetComponent<SphereCollider>());
            }

            var em = ps.emission;
            em.enabled = false;
        }
    }

    /// <summary>
    /// Called by the Animator during unit death.
    /// </summary>
    private void AnimationEventKillUnit()
    {
        if (visibleElements)
        {
            Destroy(visibleElements);
        }

        spriteRenderer.sprite = null;
        var em = ps.emission;
        em.enabled = false;
    }

    private void ResetUnit()
    {
        Health = MaxHealth;
        Ammo = Mathf.Clamp(3, 0, MaxAmmo);
        Mana = Mathf.Clamp(3, 0, MaxMana);

        ResetBuffs();
    }

    private void ResetBuffs()
    {
        if (RoundController.IsPlayerPhase == FieldController.Main.IsUnitPlayer(this))
        {
            if (PermAttack > 0)
            {
                PermAttack--;
            }

            Attack = PermAttack;
        }
        else
        {
            if (PermDefense > 0)
            {
                PermDefense--;
            }

            Defense = PermDefense;
            Thorns = 0;
        }
    }

    private int GetStandardAlgorithm()
    {
        int finalWeight;

        int moveWeight = 0;
        int healthWeight = 0;
        int buffWeight = 0;
        int resourceWeight = 0;

        int totalVanguardMoveScore = 0;
        foreach (Ability ability in VanguardAbilities)
        {
            if (ability)
            {
                if (ability.GetMoveWeight(this) > totalVanguardMoveScore)
                {
                    totalVanguardMoveScore = ability.GetMoveWeight(this);
                }
            }
        }

        if (totalVanguardMoveScore <= 0)
        {
            return 0;
        }

        int totalSupportMoveScore = 0;

        foreach (Ability ability in SupportAbilities)
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

        if ((Attack + Defense + Thorns) > 0)
        {
            buffWeight = 10;
        }

        buffWeight += ((Attack + Defense + Thorns) * 20) + (Accuracy * 10);

        if (UnitType == UnitType.Military || UnitType == UnitType.Commander)
        {
            resourceWeight += Mathf.RoundToInt(100 * ((float)Ammo / (float)MaxAmmo));
        }

        if (UnitType == UnitType.Mage || UnitType == UnitType.Commander)
        {
            resourceWeight += Mathf.RoundToInt(100 * (1 - ((float)Mana / (float)MaxMana)));
        }

        if (UnitType == UnitType.Commander)
        {
            resourceWeight = resourceWeight / 2;
        }

        finalWeight = (((2 * moveWeight) + healthWeight + resourceWeight) / 4) + buffWeight;

        /* Debug.Log(UnitName
         + "\n" + " final weight = " + finalWeight
         + "\n" + " move weight = " + moveWeight
         + "\n" + "health weight = " + healthWeight
         + "\n" + "resource weight = " + resourceWeight
         + "\n" + " weight - buffweight = " + ((2 * moveWeight + healthWeight + resourceWeight) / 4)
         + "\n" + "buffweight = " + buffWeight
        )*/

        return finalWeight;
    }

    private void AbilityDone(Unit unit)
    {
        if (unit == this)
        {
            var em = selectedps.emission;
            em.enabled = false;
        }
    }

    private void Awake()
    {
        Debug.LogWarning("FIRST");
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }

        if (!billboard)
        {
            billboard = GetComponent<Billboard>();
        }

        if (!coll)
        {
            coll = GetComponent<Collider>();
        }

        if (!spriteRenderer)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (!damageNumbers)
        {
            damageNumbers = Resources.Load("UIPrefabs/DamageText") as GameObject;
        }
    }

    private void UpdateBillboard(RoundController.PhaseType _phase)
    {
        var em = selectedps.emission;
        em.enabled = false;

        billboard.SwitchBillboardState(((int)_phase)>=2);
        if (_phase == RoundController.PhaseType.PlayerSupport && FieldController.Main.GetPosition(this) != FieldController.Position.Vanguard && FieldController.Main.IsUnitPlayer(this))
        {
            foreach (Ability ability in SupportAbilities)
            {
                if (!ability)
                {
                    continue;
                }

                if (FieldController.Main.GetValidTargets(this, ability).Count != 0)
                {
                    AbilityUsable();
                    return;
                }
            }
        }
    }
}
