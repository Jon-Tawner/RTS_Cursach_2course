using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : GameObj
{
    public Renderer MainRenderer;
    public Vector2Int Size = Vector2Int.one;


    public void SetTransparent(bool availble)
    {
        if (availble)
            MainRenderer.material.color = Color.green;
        else
            MainRenderer.material.color = Color.red;
    }

    public void SetNormal(){
        MainRenderer.material.color = Color.white;
    }

    public void OnDrawGizmosSelected()
    {
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                Gizmos.color = new Color(0f, 1f, 0f, 0.31f);
                Gizmos.DrawCube(transform.position + new Vector3(x, 0f, y), new Vector3(1f, .1f, 1f));

            }
        }
    }
}
