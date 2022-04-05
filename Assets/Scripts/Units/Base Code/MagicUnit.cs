using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicUnit : Unit
{
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
            ScoreEvents.UnitManaChanged(this, mana);
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

    protected override void SubscribeListeners()
    {
        base.SubscribeListeners();
    }

    protected override void UnsubscribeListeners()
    {
        base.UnsubscribeListeners();
    }
}
