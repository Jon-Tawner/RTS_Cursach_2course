using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Close
{
    private void Start() {
        MaxHP = HP = 100;
        GoldCost = 300;
        Resistance = 3;
        TimeCreate = 10;
        AttackDistance = 4;
        Damage = 30;
        SpeedAttack = 0.4f;
    }
}
