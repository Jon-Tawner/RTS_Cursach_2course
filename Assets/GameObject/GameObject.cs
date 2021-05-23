using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameObj : MonoBehaviour
{
    public float HP = 0;
    public float GoldCost = 0;
    public float Resistance = 0;
    public bool Friend = true;
    public bool isSelect;

    private void Update()
    {
        if (HP <= 0)
            Destroy(gameObject);
    }
}

