using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResControl : MonoBehaviour
{
    public Text resourceText;

    public float goldFriend;
    public float goldEnemy;
    public float eatFriend;
    public float eatEnemy;
    public int MaxPopulationFriend;
    public int MaxPopulationEnemy;
    public bool multiSelect = false;


    public List<GameObj> unitsFriend;
    public List<GameObj> unitsEnemy;
    public List<GameObj> buildsFriend;
    public List<GameObj> buildsEnemy;
    public GameObj TowerFriend;
    public GameObj TowerEnemy;

    void Update()
    {
        resourceText.text = "Золото: " + goldFriend + "  Еда: " + eatEnemy + " | " + "Население: " +
            unitsFriend.Count + " Строений " + buildsFriend.Count;

        if (TowerFriend == null)
            SceneManager.LoadScene("Scenes/Failure");
        if (TowerEnemy == null)
            SceneManager.LoadScene("Scenes/Win");
    }

    public void NewUnit(GameObj unit, bool friend)
    {
        if (friend)
            unitsFriend.Add(unit);
        else
            unitsEnemy.Add(unit);
    }

    public void NewBuild(GameObj build, bool friend)
    {
        if (friend)
            buildsFriend.Add(build);
        else
            buildsEnemy.Add(build);
    }
}
