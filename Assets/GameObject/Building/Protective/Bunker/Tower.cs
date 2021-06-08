using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Protective
{
    private int capacity = 3;

    private void Start() {
        MaxHP = HP = 350;
        GoldCost = 200;
        Resistance = 4;
    }
}
