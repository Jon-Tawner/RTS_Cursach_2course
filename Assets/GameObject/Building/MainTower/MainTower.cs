using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTower : Building
{
    public int Gold=0;
    // Start is called before the first frame update
    void Start()
    {
        Resistance = 15;
        HP = 3000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
