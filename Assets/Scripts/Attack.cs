using System;
using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    private Unit thisGO;
    private ResControl resurs;
    private Animator animator;
    private bool temp;
    private float dist = 0;
    // Start is called before the first frame update
    private void Start()
    {
        thisGO = GetComponent<Unit>();
        animator = GetComponent<Animator>();

        GameObject ScriptResurs = GameObject.FindGameObjectWithTag("GameController");
        resurs = ScriptResurs.GetComponent<ResControl>();

        StartCoroutine(AttackFoo());

    }

    // Update is called once per frame
    private void Update()
    {
    }

    public IEnumerator AttackFoo()
    {
        while (true)
        {
            if (thisGO.Friend)
            {
                foreach (GameObj obj in resurs.unitsEnemy)
                {
                    dist = Vector3.Distance(obj.transform.position, this.transform.position);
                    if (thisGO.AttackDistance >= dist)
                    {
                        temp = true;
                        if (thisGO.Damage > obj.Resistance)
                            obj.HP -= thisGO.Damage - obj.Resistance;
                        break;
                    }
                }
                foreach (GameObj obj in resurs.buildsEnemy)
                {
                    dist = Vector3.Distance(obj.transform.position, this.transform.position);
                    if (thisGO.AttackDistance >= dist)
                    {
                        temp = true;
                        if (thisGO.Damage > obj.Resistance)
                            obj.HP -= thisGO.Damage - obj.Resistance;
                        break;
                    }
                }
            }
            else
            {
                foreach (GameObj obj in resurs.unitsFriend)
                {
                    dist = Vector3.Distance(obj.transform.position, this.transform.position);
                    if (thisGO.AttackDistance >= dist)
                    {
                        temp = true;
                        if (thisGO.Damage > obj.Resistance)
                            obj.HP -= thisGO.Damage - obj.Resistance;
                        break;
                    }
                }
                foreach (GameObj obj in resurs.buildsFriend)
                {
                    dist = Vector3.Distance(obj.transform.position, this.transform.position);
                    if (thisGO.AttackDistance >= dist)
                    {
                        temp = true;
                        if (thisGO.Damage > obj.Resistance)
                            obj.HP -= thisGO.Damage - obj.Resistance;
                        break;
                    }
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

            yield return new WaitForSeconds(thisGO.SpeedAttack);
        }
    }
}
