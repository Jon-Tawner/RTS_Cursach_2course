using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Close
{
    private void Start()
    {
        MaxHP = HP = 100;
        GoldCost = 300;
        Resistance = 3;
        TimeCreate = 10;
        AttackDistance = 2;
        Damage = 30;
        SpeedAttack = 3f;
        this.GetComponent<Animator>().speed = SpeedAttack - 2f;
    }
}
