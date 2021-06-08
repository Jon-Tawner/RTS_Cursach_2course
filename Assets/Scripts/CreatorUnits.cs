using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatorUnits : MonoBehaviour
{

    private Vector3 Pos_MainTower;

    private void Start()
    {
        Pos_MainTower = GetComponent<ResControl>().TowerFriend.transform.position;
    }

    public void CreateUnit(Unit unit)
    {
        if (unit.GetGoldCost() <= this.GetComponent<ResControl>().goldFriend)
        {
            this.GetComponent<ResControl>().goldFriend -= unit.GetGoldCost();
            unit.GetComponent<Attack>().enabled = true;
            unit.GetComponent<UnitControl>().enabled = true;
            unit.GetComponent<ShowPanelGO>().enabled = true;
            unit.GetComponent<NavMeshAgent>().enabled = true;
            Instantiate(unit, Pos_MainTower - Vector3.one, Quaternion.identity);
        }
    }

}
