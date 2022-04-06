using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MilitaryUnit
{
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        Ammo = MaxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
