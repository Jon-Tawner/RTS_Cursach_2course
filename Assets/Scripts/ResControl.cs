using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResControl : MonoBehaviour
{
    public Text resourceText;

    private int gold;
    private int eat;
    private int population;

    public List<GameObject> units;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        population = units.Count;
        resourceText.text = "Золото: " + gold + "  Еда: " + eat + " | " + "Население: " + population;
    }

    public void NewUnit(GameObject unit)
    {
        units.Add(unit);
    }
}
