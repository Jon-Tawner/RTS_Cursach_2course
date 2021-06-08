using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class UnitControl : MonoBehaviour
{
    public bool unitCanWalk = true;

    private Camera MainCamera;
    private SpriteRenderer sprite;
    private NavMeshPath controller;
    private RaycastHit hit;
    private NavMeshAgent agent;
    private GameObj thisGO;
    private Transform positionTower;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        controller = new NavMeshPath();
        thisGO = GetComponent<GameObj>();
        hit.point = thisGO.transform.position;

        GameObject GO = GameObject.FindGameObjectWithTag("GameController");
        ResControl resurs = GO.GetComponent<ResControl>();
        resurs.NewUnit(thisGO, thisGO.IsFriend());
        if (!thisGO.IsFriend())
        {
            positionTower = resurs.TowerFriend.transform;
            hit.point = positionTower.position+Vector3.right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().transform.Rotate(-90, 0f, 0f);
        GetComponent<SpriteRenderer>().transform.Rotate(-90, 0f, 0f);
        transform.Rotate(-90, 0f, 0f);
        if (unitCanWalk)
        {
            if (thisGO.IsFriend() && thisGO.IsSelect() && Input.GetMouseButtonDown(1))
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

            agent.SetDestination(hit.point);

            if (agent.velocity.magnitude > 0)
            {
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }
        }
        else 
            agent.SetDestination(transform.position);
    }
}
