using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame_SCRPT : MonoBehaviour
{

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync("Start Screen");
    }
}
