using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Close
{
    
    // Start is called before the first frame update
    void Start()
    {
        HP = 300;
        Resistance = 10;
        Damage = 70;
        AttackDistance = SquareDistance;
        GoldCost = 200;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
