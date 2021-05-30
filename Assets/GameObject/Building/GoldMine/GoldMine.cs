using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : Building
{
    public int SpeedMine = 10;

    private GameObj thisGO;
    private ResControl resources;

    void Start()
    {
        thisGO = GetComponent<GameObj>();

        GameObject GO = GameObject.FindGameObjectWithTag("GameController");
        resources = GO.GetComponent<ResControl>();

        StartCoroutine(Goldfarm());
    }

    private IEnumerator Goldfarm()
    {
        while (true)
        {
            if (thisGO.Friend)
                resources.goldFriend += SpeedMine;
            else
                resources.goldEnemy += SpeedMine;

            yield return new WaitForSeconds(1f);
        }
    }
}
