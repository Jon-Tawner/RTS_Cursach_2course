using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : GameObj
{
    protected float AttackDistance = 0;
    protected float Damage = 0;
    protected float SpeedAttack = 0;

    public float GetAttackDistance()
    {
        return AttackDistance;
    }

    public float GetDamage()
    {
        return Damage;
    }

    public float GetSpeedAttack()
    {
        return SpeedAttack;
    }

}
