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
    private Unit thisGO;
    private Transform positionTower;
    private ResControl resurs;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        controller = new NavMeshPath();
        thisGO = GetComponent<Unit>();
        hit.point = thisGO.transform.position;

        GameObject GO = GameObject.FindGameObjectWithTag("GameController");
        resurs = GO.GetComponent<ResControl>();
        resurs.NewUnit(thisGO, thisGO.IsFriend());

        if (!thisGO.IsFriend())
        {
            positionTower = resurs.TowerFriend.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObj obj = null;
        GetComponent<Animator>().transform.Rotate(-90, 0f, 0f);
        GetComponent<SpriteRenderer>().transform.Rotate(-90, 0f, 0f);
        transform.Rotate(-90, 0f, 0f);
        if (unitCanWalk)
        {
            if (!thisGO.IsFriend())
            {
                obj = thisGO.GetObjectInRadius(resurs.unitsFriend, thisGO.GetViewDistance());
                if (obj != null)
                    hit.point = obj.transform.position;
                else
                    hit.point = positionTower.position + Vector3.right;
            }
            else
            {
                if (thisGO.IsFriend() && thisGO.IsSelect() && Input.GetMouseButtonDown(1))
                    Physics.Raycast(MainCamera.ScreenPointToRay(Input.mousePosition), out hit);

                if (thisGO.Friend && !thisGO.IsSelect())
                {
                    obj = thisGO.GetObjectInRadius(resurs.unitsEnemy, thisGO.GetViewDistance());
                    if (obj != null)
                        obj = thisGO.GetObjectInRadius(resurs.buildsEnemy, thisGO.GetViewDistance());
                }
                if (obj != null)
                    hit.point = obj.transform.position;
            }

            if (hit.point.x < transform.position.x)
                sprite.flipX = true;
            else
                sprite.flipX = false;

            agent.SetDestination(hit.point);

            if (agent.velocity.magnitude > 0)
                animator.SetBool("Walk", true);
            else
                animator.SetBool("Walk", false);

        }
        else
            agent.SetDestination(transform.position);
    }
}
