using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : Distant
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 150;
        Resistance = 4;
        Damage = 80;
        AttackDistance = 13;
        GoldCost = 160; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
