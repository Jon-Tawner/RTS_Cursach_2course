using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peasant : Close
{
    // Start is called before the first frame update
    void Start()
    {
       HP = 100;
       Damage = 20;
       AttackDistance = SquareDistance;
       GoldCost = 30; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
