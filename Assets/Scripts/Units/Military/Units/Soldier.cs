using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MilitaryUnit
{
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        maxAmmunition = 5;
        ammunition = maxAmmunition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Ability()
    {
        
    }
}
