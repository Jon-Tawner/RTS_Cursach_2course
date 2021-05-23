using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.AI;

public class SelectUnits : MonoBehaviour
{
    public Texture selectTexture;

    private ShowPanelGO setMultyManel;

    private Ray ray;
    private RaycastHit hit;
    private Vector3 mouseStartPosition;
    private Vector3 selectionStartPoint;
    private Vector3 selectionEndPoint;
    private float mouseX;
    private float mouseY;
    private float selectionWeight;
    private float selectionHeight;
    private ResControl resources;
    private bool toSelecting;


    // Start is called before the first frame update
    void Start()
    {
        resources = GetComponent<ResControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            toSelecting = true;
            mouseStartPosition = Input.mousePosition;

            ray = Camera.main.ScreenPointToRay(mouseStartPosition);

            if (Physics.Raycast(ray, out hit))
            {
                selectionStartPoint = hit.point;
            }
        }
        mouseX = Input.mousePosition.x;
        mouseY = Screen.height - Input.mousePosition.y;
        selectionWeight = mouseStartPosition.x - mouseX;
        selectionHeight = Input.mousePosition.y - mouseStartPosition.y;

        if (Input.GetMouseButtonUp(0))
        {
            toSelecting = false;
            resources.multiSelect = false;
            DeselectAll();

            if (mouseStartPosition == Input.mousePosition)
            {
                SingleSelect();
            }
            else
            {
                MultiSelect();
            }
        }

    }

    private void MultiSelect()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            selectionEndPoint = hit.point;
        }
        SelectHightlighted();
        resources.multiSelect = true;
    }

    private void SelectHightlighted()
    {
        foreach (GameObj unit in resources.unitsFriend)
        {
            float x = unit.transform.position.x;
            float z = unit.transform.position.z;

            if ((x > selectionStartPoint.x && x < selectionEndPoint.x) || (x < selectionStartPoint.x && x > selectionEndPoint.x))
            {
                if ((z > selectionStartPoint.z && z < selectionEndPoint.z) || (z < selectionStartPoint.z && z > selectionEndPoint.z))
                {
                    unit.GetComponent<GameObj>().isSelect = true;
                }
            }
        }
    }

    private void SingleSelect()
    {
        string tag = hit.collider.gameObject.tag;
        if (tag == "Unit"||tag=="Building")
        {
            hit.collider.gameObject.GetComponentInParent<GameObj>().isSelect = true;
        }

    }

    private void DeselectAll()
    {
        foreach (GameObj unit in resources.unitsFriend)
        {
            unit.GetComponent<GameObj>().isSelect = false;
        }
        foreach (GameObj build in resources.buildsFriend)
        {
            build.GetComponent<GameObj>().isSelect = false;
        }
    }

    void OnGUI()
    {
        if (toSelecting)
        {
            GUI.DrawTexture(new Rect(mouseX, mouseY, selectionWeight, selectionHeight), selectTexture);
        }
    }
}
