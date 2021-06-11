using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    public GameObject obj;

    void Update()
    {
        print(Vector3.Distance(obj.GetComponent<BoxCollider>().ClosestPoint(this.transform.position), this.transform.position));
    }
}
