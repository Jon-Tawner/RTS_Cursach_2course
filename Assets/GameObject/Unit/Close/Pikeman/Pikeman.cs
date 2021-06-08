using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pikeman : Close
{
    private void Start() {
        MaxHP = HP = 60;
        GoldCost = 140;
        Resistance = 1;
        TimeCreate = 4;
        AttackDistance = 4;
        Damage = 15;
        SpeedAttack = 0.7f;
    }
}
