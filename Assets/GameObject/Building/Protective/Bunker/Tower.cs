using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Protective
{
    public int capacity = 3;
    // Start is called before the first frame update
    void Start()
    {
        HP = 1500;
        GoldCost = 1800;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
