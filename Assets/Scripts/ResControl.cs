using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResControl : MonoBehaviour
{
    public Text resourceText;

    private int gold;
    private int eat;
    private int population;
    public bool multiSelect = false;

    public List<GameObject> unitsFriend;
    public List<GameObject> unitsEnemy;
    public List<GameObject> buildsFriend;
    public List<GameObject> buildsEnemy;
    public GameObj TowerFriend;
    public GameObj TowerEnemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        resourceText.text = "Золото: " + gold + "  Еда: " + eat + " | " + "Население: " +
            unitsFriend.Count + " Строений " + buildsFriend.Count;

        if (TowerFriend == null)
            SceneManager.LoadScene(5);
        if (TowerEnemy == null)
            SceneManager.LoadScene(4);
    }

    public void NewUnit(GameObject unit, bool friend)
    {
        if (friend)
            unitsFriend.Add(unit);
        else
            unitsEnemy.Add(unit);
    }

    public void NewBuild(GameObject build, bool friend)
    {
        if (friend)
            buildsFriend.Add(build);
        else
            buildsEnemy.Add(build);
    }
}
