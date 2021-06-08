using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Close
{
    private void Start() {
        MaxHP = HP = 70;
        GoldCost = 150;
        Resistance = 2;
        TimeCreate = 5;
        AttackDistance = 4;
        Damage = 15;
        SpeedAttack = 0.7f;
    }
}
