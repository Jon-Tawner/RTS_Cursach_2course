using System;
using UnityEngine;
using UnityEngine.UI;

public class GameObj : MonoBehaviour
{
    protected float HP = 0;
    protected float MaxHP = 0;
    protected float GoldCost = 0;
    protected float Resistance = 0;
    protected float TimeCreate = 0;
    public bool Friend;
    private bool isSelect;


    protected void Update()
    {
        if (HP <= 0)
        {
            isSelect = false;
            Destroy(this.gameObject);
        }
    }

    public float GetTimeCreate()
    {
        return TimeCreate;
    }

    public float GetResistance()
    {
        return Resistance;
    }

    public float GetHP()
    {
        return HP;
    }

    public float GetMaxHP()
    {
        return MaxHP;
    }

    public float GetGoldCost()
    {
        return GoldCost;
    }

    public bool IsFriend()
    {
        return Friend;
    }

    public bool IsSelect()
    {
        return isSelect;
    }
    
    public void SetTimeCreate(float newTimeCreate)
    {
        TimeCreate = newTimeCreate;
    }

    public void SetResistance(float newResistance)
    {
        Resistance = newResistance;
    }

    public void SetHP(float newHP)
    {
        HP = newHP;
    }

    public void SetGoldCost(float NewGoldCost)
    {
        GoldCost = NewGoldCost;
    }

    public void SetIsSelect(bool NewIsSelect)
    {
        isSelect = NewIsSelect;
    }
}

