using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameObj thisGO;
    private ResControl resurs;
    private Animator animator;
    private bool temp;

    // Start is called before the first frame update
    void Start()
    {
        thisGO = GetComponent<GameObj>();
        animator = GetComponent<Animator>();

        GameObject ScriptResurs = GameObject.FindGameObjectWithTag("GameController");
        resurs = ScriptResurs.GetComponent<ResControl>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = 0;
        float x = 0;
        float y = 0;
        if (thisGO.Friend)
        {
            foreach (GameObject unit in resurs.unitsEnemy)
            {
                x = unit.transform.position.x - this.transform.position.x;
                y = unit.transform.position.y - this.transform.position.y;
                dist = Mathf.Pow(x, 2) + Mathf.Pow(y, 2);
                dist = Mathf.Sqrt(dist);
                if (thisGO.AttackDistance >= dist)
                    temp = true;
            }
        }
        else
        {
            foreach (GameObject unit in resurs.unitsFriend)
            {
                x = unit.transform.position.x - this.transform.position.x;
                y = unit.transform.position.y - this.transform.position.y;
                dist = Mathf.Pow(x, 2) + Mathf.Pow(y, 2);
                dist = Mathf.Sqrt(dist);
                if (thisGO.AttackDistance >= dist)
                    temp = true;
            }
        }

        if (temp)
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
        temp = false;
    }
}
