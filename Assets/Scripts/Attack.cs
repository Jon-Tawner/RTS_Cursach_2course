using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Unit thisGO;
    private ResControl resurs;
    private Animator animator;
    private UnitControl unitControl;
    private bool isAttack;
    private float dist = 0;

    private void Start()
    {
        thisGO = GetComponent<Unit>();
        animator = GetComponent<Animator>();
        unitControl = GetComponent<UnitControl>();

        GameObject ScriptResurs = GameObject.FindGameObjectWithTag("GameController");
        resurs = ScriptResurs.GetComponent<ResControl>();

        StartCoroutine(AttackFoo());

    }

    public IEnumerator AttackFoo()
    {
        while (true)
        {
            if (!thisGO.isSelect)
            {
                if (thisGO.Friend)
                {
                    isAttack = FooAttack(resurs.unitsEnemy);
                    if (!isAttack)
                        isAttack = FooAttack(resurs.buildsEnemy);
                }
                else
                {
                    isAttack = FooAttack(resurs.unitsFriend);
                    if (!isAttack)
                        isAttack = FooAttack(resurs.buildsFriend);
                }
                unitControl.unitCanWalk = !isAttack;

                if (isAttack)
                {
                    animator.SetBool("Attack", true);
                }
                else
                {
                    animator.SetBool("Attack", false);
                }
                isAttack = false;
            }
            else
            {
                unitControl.unitCanWalk = true;
                animator.SetBool("Attack", false);
            }
            yield return new WaitForSeconds(thisGO.SpeedAttack);

        }
    }
    private bool FooAttack(List<GameObj> list)
    {
        foreach (GameObj obj in list)
        {
            dist = Vector3.Distance(obj.transform.position, this.transform.position);
            if (thisGO.AttackDistance >= dist)
            {
                if (thisGO.Damage > obj.Resistance)
                    obj.HP -= thisGO.Damage - obj.Resistance;
                if(obj.HP<=0)
                    list.Remove(obj);
                return true;
            }
        }
        return false;
    }
}

