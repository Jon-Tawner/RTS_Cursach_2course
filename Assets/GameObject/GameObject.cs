using System;
using UnityEngine;
using UnityEngine.UI;

public class GameObj : MonoBehaviour
{
    public float HP = 0;
    public float MaxHP = 0;
    public float GoldCost = 0;
    public float Resistance = 0;
    public float TimeCreate = 0;
    public bool Friend = true;
    public bool isSelect;

    private void Start()
    {
        MaxHP = HP;
    }

    protected void Update()
    {
        if (HP <= 0)
        {
            isSelect = false;
            GetComponent<Animator>().SetBool("Die",true);
            Destroy(this.gameObject, 2f);
        }
    }
}

