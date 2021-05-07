using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameObj : MonoBehaviour
{  
public double SquareDistance = 50; //?какое
public float HP = 0;
public float GoldCost = 0;
public float Resistance = 0;
public double SquareSpeed;
public bool Friend = true;

    // Start is called before the first frame update
    void Start()
    {
        SquareSpeed =SquareDistance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
