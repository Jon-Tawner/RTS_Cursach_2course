using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitWalk : MonoBehaviour
{
    private Camera MainCamera;
    private NavMeshPath controller;
    private Transform transformUnit;
    private Rigidbody rigidbod;
    public float UnitSpeed = 10;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        transformUnit = GetComponent<Transform>();
        rigidbod = GetComponent<Rigidbody>();
        //agent = GetComponent<NavMeshAgent>();
        controller = new NavMeshPath();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hit);
        }
        NavMesh.CalculatePath(transformUnit.position, hit.point, NavMesh.AllAreas, controller);
        if (!Mathf.Approximately(controller.corners[0].magnitude, controller.corners[1].magnitude))
        {
            rigidbod.position = Vector3.Lerp(transform.position, controller.corners[1], 1 / (UnitSpeed * (Vector3.Distance(transform.position, controller.corners[1]))));
        }

    }
}
