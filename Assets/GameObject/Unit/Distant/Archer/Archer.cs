using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Distant
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 120;
        Resistance = 3;
        Damage = 55;
        AttackDistance = 15*SquareDistance;
        GoldCost = 110;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
