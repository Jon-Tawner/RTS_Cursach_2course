using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : Building
{
    public int SpeedMine = 10;
    // Start is called before the first frame update
    void Start()
    {
        Resistance = 10;
        HP = 1500;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
