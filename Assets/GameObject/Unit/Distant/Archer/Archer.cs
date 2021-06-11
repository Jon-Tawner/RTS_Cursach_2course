using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Distant
{
    private void Start()
    {
        MaxHP = HP = 50;
        GoldCost = 140;
        Resistance = 0.7f;
        TimeCreate = 3;
        AttackDistance = 7;
        Damage = 12;
        SpeedAttack = 2f;
        this.GetComponent<Animator>().speed = SpeedAttack - 0.5f;
    }
}
