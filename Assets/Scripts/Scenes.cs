using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void ChangeScenes(int NumberScenes)
    {
        SceneManager.LoadScene(NumberScenes);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void Update() {
        if(Input.GetKey(UnityEngine.KeyCode.Escape))
            SceneManager.LoadScene(0);

    }
}
