using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Close
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 250;
        Resistance = 5;
        Damage = 40;
        AttackDistance = 3;
        GoldCost = 80;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
