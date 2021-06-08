using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : Distant
{
    private void Start() {
        MaxHP = HP = 60;
        GoldCost = 170;
        Resistance = 1;
        TimeCreate = 4;
        AttackDistance = 7;
        Damage = 20;
        SpeedAttack = 0.4f;
    }
}
