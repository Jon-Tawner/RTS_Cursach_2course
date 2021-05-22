using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPanelGO : MonoBehaviour
{
    private GameObject MultiSelectGO;
    private bool isMultiSelect = false;
    private bool temp = true;
    private GameObj GO;
    public List<GameObject> panels;

    private void Start()
    {
        MultiSelectGO = GameObject.FindGameObjectWithTag("GameController");
        GO = GetComponent<GameObj>();
    }

    void Update()
    {
        if (GO.Friend)
        {
            isMultiSelect = MultiSelectGO.GetComponent<ResControl>().multiSelect;
            if (GO.isSelect && !isMultiSelect)
            {
                foreach (GameObject item in panels)
                {
                    item.SetActive(true);
                }
                temp = GO.isSelect;
            }
            else if (GO.isSelect != temp)
            {
                foreach (GameObject item in panels)
                {
                    item.SetActive(false);
                }
                temp = GO.isSelect;
            }
        }
    }
}
