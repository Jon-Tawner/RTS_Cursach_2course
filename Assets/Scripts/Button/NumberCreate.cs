using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberCreate : MonoBehaviour
{
    private int numb;
    private Text TNumb;
    private GameObject gameController;

    public Unit unit;

    private void Start()
    {
        TNumb = GetComponentInChildren<Text>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        StartCoroutine(StartCreateUnit());
    }

    public void IncrementNumb()
    {
        ++numb;
        TNumb.text = Convert.ToString(numb);
    }

    public IEnumerator StartCreateUnit()
    {

        while (true)
        {
            if (numb > 0)
            {
                gameController.GetComponent<CreatorUnits>().CreateUnit(unit);
                --numb;
                TNumb.text = Convert.ToString(numb);
            }

            yield return new WaitForSeconds(unit.TimeCreate);
        }
    }

}
