using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Close
{
    private void Start()
    {
        MaxHP = HP = 70;
        GoldCost = 150;
        Resistance = 2;
        TimeCreate = 5;
        AttackDistance = 2;
        Damage = 15;
        SpeedAttack = 2f;
        this.GetComponent<Animator>().speed = SpeedAttack;
    }
}
