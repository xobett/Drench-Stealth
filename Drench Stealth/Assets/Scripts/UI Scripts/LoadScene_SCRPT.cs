using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene_SCRPT : MonoBehaviour
{
    public string sceneToLoad;
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(sceneToLoad);
    }

    public void LoadCredits()
    {
        SceneManager.LoadSceneAsync("Credits Screen");
    }
}
