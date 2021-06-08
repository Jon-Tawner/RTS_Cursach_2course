using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kastyl : MonoBehaviour
{
    public GameObject kastyl;

    private void Update()
    {
        if (kastyl.active)
            this.GetComponent<BoxCollider>().enabled = true;
        else
            this.GetComponent<BoxCollider>().enabled = false;

    }


}
