using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pikeman : Close
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 200;
        Resistance = 3;
        Damage = 70;
        AttackDistance = 2 * SquareDistance;
        GoldCost = 130;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
