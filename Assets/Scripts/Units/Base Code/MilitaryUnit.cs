using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MilitaryUnit : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
