using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTower : Building
{
    private void Start() {
        MaxHP = HP = 1000;
        Resistance = 8;
    }
}
