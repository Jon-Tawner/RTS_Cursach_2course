using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitWalk : MonoBehaviour
{
    private Camera MainCamera;
    private NavMeshPath controller;
    private RaycastHit hit;
    private NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = true;
        controller = new NavMeshPath();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hit);
            agent.CalculatePath(hit.point, controller);
        }
        agent.SetDestination(hit.point);

    }
}
