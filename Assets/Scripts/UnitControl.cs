using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class UnitControl : MonoBehaviour
{
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
        agent.updateRotation = true;
        controller = new NavMeshPath();
        thisGO = GetComponent<GameObj>();
        hit.point = thisGO.transform.position;

        GameObject GO = GameObject.FindGameObjectWithTag("GameController");
        ResControl resurs = GO.GetComponent<ResControl>();
        resurs.NewUnit(thisGO, thisGO.Friend);
        if (!thisGO.Friend)
        {
            positionTower = resurs.TowerFriend.transform;
            hit.point = positionTower.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (thisGO.Friend && thisGO.isSelect && Input.GetMouseButtonDown(1))
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
}
