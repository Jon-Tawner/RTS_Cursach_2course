using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : GameObj
{
    protected float AttackDistance = 0;
    protected float ViewDistance = 10;
    protected float Damage = 0;
    protected float SpeedAttack = 0;

    public float GetAttackDistance()
    {
        return AttackDistance;
    }

    public float GetViewDistance()
    {
        return ViewDistance;
    }

    public float GetDamage()
    {
        return Damage;
    }

    public float GetSpeedAttack()
    {
        return SpeedAttack;
    }

    public GameObj GetObjectInRadius(List<GameObj> list, float radius)
    {
        foreach (GameObj obj in list)
        {
            float dist = Vector3.Distance(obj.transform.position, this.transform.position);
            if (radius >= dist)
                return obj;
        }
        return null;
    }

}
