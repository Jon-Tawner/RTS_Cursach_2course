using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGrids : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(20, 20);

    private Building[,] grid;
    private Building flyBuilding;
    private Camera mainCamera;


    // Start is called before the first frame update
    private void Start()
    {
        grid = new Building[GridSize.x, GridSize.y];

        mainCamera = Camera.main;
    }

    public void StartPlacingBuilding(Building buildingPrefab)
    {
        Debug.Log("heyoo");

        if (flyBuilding != null)
        {
            Destroy(flyBuilding.gameObject);
        }
        flyBuilding = Instantiate(buildingPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (flyBuilding != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float hit))
            {
                Vector3 worldPosition = ray.GetPoint(hit);

                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);

                bool available = true;

                if (x < (GridSize.x / -2) || x > GridSize.x - flyBuilding.Size.x) available = false;
                if (y < (GridSize.y / -2) || y > GridSize.y - flyBuilding.Size.y) available = false;
                if(available && IsPlaceTaken(x,y))  available = false;

                flyBuilding.transform.position = new Vector3(x, 1, y);
                flyBuilding.SetTransparent(available);

                if (available && Input.GetMouseButtonDown(0))
                {
                    for (int j = 0; j < flyBuilding.Size.x; j++)
                    {
                        for (int k = 0; k < flyBuilding.Size.y; k++)
                        {
                            grid[x + j, y + k] = flyBuilding;
                        }

                    }

                    flyBuilding.SetNormal();
                    flyBuilding = null;
                }

            }

        }
    }

    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < flyBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyBuilding.Size.y; y++)
            {
                if (grid[placeX + x, placeY + y] != null) return true;
            }
        }
        return false;
    }
}
