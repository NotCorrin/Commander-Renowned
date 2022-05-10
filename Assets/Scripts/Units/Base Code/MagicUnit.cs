using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MagicUnit : Unit
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void SubscribeListeners()
    {
        GameEvents.onUseMana += OnUseMana;
        base.SubscribeListeners();
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onUseMana -= OnUseMana;
        base.UnsubscribeListeners();
    }

    private void OnUseMana(Unit caster, int cost)
    {
        if (caster == this)
        {
            Mana -= cost;
        }
    }

    protected override void ResetUnit () {
        Mana = MaxMana/2;
		base.ResetUnit();
	}
}
