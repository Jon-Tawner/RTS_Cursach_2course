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
        Vector3 closestPointOnCollider;
        foreach (GameObj obj in list)
        {
            if (obj.tag == "Building")
                closestPointOnCollider = obj.GetComponent<BoxCollider>().ClosestPoint(this.transform.position);
            else
                closestPointOnCollider = obj.transform.position;
                
            float dist = Vector3.Distance(closestPointOnCollider, this.transform.position);
            if (radius >= dist)
                return obj;
        }
        return null;
    }

}
