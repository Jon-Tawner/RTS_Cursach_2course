using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peasant : Close
{
    private void Start()
    {
        MaxHP = HP = 40;
        GoldCost = 65;
        Resistance = 0.5f;
        TimeCreate = 1;
        AttackDistance = 2;
        Damage = 5;
        SpeedAttack = 1.8f;
        this.GetComponent<Animator>().speed = SpeedAttack;
    }
}
