using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryUnit : Unit
{
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
            ammo = Mathf.Min(Mathf.Max(value, 0), MaxAmmo);
            UIEvents.UnitAmmoChanged(this, ammo);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override int GetStickScore()
    {
        throw new System.NotImplementedException();
    }

    public override int GetSwitchScore()
    {
        throw new System.NotImplementedException();
    }

    protected override void ResetUnit()
    {
        base.ResetUnit();
        Ammo = MaxAmmo;
    }

    protected override void SubscribeListeners()
    {
        GameEvents.onUseAmmo += OnUseAmmo;
        base.SubscribeListeners();
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onUseAmmo -= OnUseAmmo;
        base.UnsubscribeListeners();
    }

    private void OnUseAmmo(Unit caster, int cost)
    {
        if (caster == this)
        {
            Ammo -= cost;
        }
    }
}
