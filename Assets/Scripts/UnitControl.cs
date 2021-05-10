using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class UnitControl : MonoBehaviour
{
    private Camera MainCamera;
    private Vector3 targetPosition;
    private SpriteRenderer sprite;
    private NavMeshPath controller;
    private RaycastHit hit;
    private NavMeshAgent agent;
    private Vector3 vector3 = Vector3.zero;
    public float UnitSpeed;
    public bool isSelect;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = true;
        controller = new NavMeshPath();

        GameObject GO = GameObject.FindGameObjectWithTag("GameController");
        ResControl resurs = GO.GetComponent<ResControl>();
        resurs.NewUnit(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && isSelect)
        {
            Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hit);

            if (hit.point.x < transform.position.x)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }

        agent.CalculatePath(hit.point, controller);

        agent.SetDestination(hit.point);

        if (agent.velocity.magnitude > 0)
        {
            animator.SetBool("Walk", true);
        }
        else{
            animator.SetBool("Walk", false);
        }

    }
}
