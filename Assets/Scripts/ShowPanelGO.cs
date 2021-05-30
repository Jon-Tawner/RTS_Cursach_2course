using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPanelGO : MonoBehaviour
{
    private bool isMultiSelect = false;
    private bool ischange = true;

    private ResControl control;
    private Text panelHP;
    private GameObject MultiSelectGO;
    private GameObj GO;
    public List<GameObject> panels;

    private void Start()
    {
        GO = GetComponent<GameObj>();
        panelHP = panels[0].GetComponentInChildren<Text>();
        MultiSelectGO = GameObject.FindGameObjectWithTag("GameController");
        control = MultiSelectGO.GetComponent<ResControl>();
    }

    void Update()
    {
        if (GO.Friend)
        {
            isMultiSelect = control.multiSelect;
            if (GO.isSelect && !isMultiSelect)
            {
                foreach (GameObject item in panels)
                {
                    item.SetActive(true);
                }
                panelHP.text = Convert.ToString(GO.HP) + '/' + Convert.ToString(GO.MaxHP);
                ischange = GO.isSelect;
            }
            else if (GO.isSelect != ischange)
            {
                foreach (GameObject item in panels)
                {
                    item.SetActive(false);
                }
                ischange = GO.isSelect;
            }
        }
    }
}
