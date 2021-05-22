using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RepeatNavMeshBuild : MonoBehaviour
{
    private GameObject GO;
    private ResControl res;
    private int nowCountBuild = 0;
    // Start is called before the first frame update
    void Start()
    {
        GO = GameObject.FindGameObjectWithTag("GameController");
        res = GO.GetComponent<ResControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (res.buildsFriend.Count + res.buildsEnemy.Count != nowCountBuild)
        {
            GetComponent<NavMeshSurface>().BuildNavMesh();
            nowCountBuild = res.buildsFriend.Count + res.buildsEnemy.Count;
        }
    }
}
