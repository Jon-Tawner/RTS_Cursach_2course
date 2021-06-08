using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peasant : Close
{
    private void Start() {
        MaxHP = HP = 40;
        GoldCost = 65;
        Resistance = 0.5f;
        TimeCreate = 1;
        AttackDistance = 4;
        Damage = 5;
        SpeedAttack = 0.8f;
    }
}
