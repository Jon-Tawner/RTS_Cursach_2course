using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGrids : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(0, 0);

    private Building[,] grid;
    private Building flyBuilding;
    private Camera mainCamera;
    private RaycastHit hit;

    // Start is called before the first frame update
    private void Start()
    {
        grid = new Building[GridSize.x, GridSize.y];

        mainCamera = Camera.main;
    }

    public void StartPlacingBuilding(Building buildingPrefab)
    {
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
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                int x = Mathf.RoundToInt(hit.point.x);
                int y = Mathf.RoundToInt(hit.point.z);

                bool available = true;

                if (x < 2 || x > GridSize.x - flyBuilding.Size.x) available = false;
                if (y < 2 || y > GridSize.y - flyBuilding.Size.y) available = false;
                if (hit.collider.tag != "Ground") available = false;
                if (available && IsPlaceTaken(x, y)) available = false;

                flyBuilding.transform.position = new Vector3(x, 2, y);
                flyBuilding.SetTransparent(available);

                if (Input.GetMouseButtonDown(1))
                {
                    Destroy(flyBuilding.gameObject);
                    flyBuilding = null;
                }

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
                    flyBuilding.GetComponent<BuildControl>().enabled = true;
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
