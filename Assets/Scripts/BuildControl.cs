using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObj thisGO = GetComponent<GameObj>();
        GameObject ScriptResurs = GameObject.FindGameObjectWithTag("GameController");
        ResControl resurs = ScriptResurs.GetComponent<ResControl>();
        resurs.NewBuild(thisGO, thisGO.IsFriend());
    }


}
