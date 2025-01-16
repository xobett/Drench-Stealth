using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions_SCRPT : MonoBehaviour
{
    private GameObject pausedMenu;

    private void Start()
    {
        pausedMenu = gameObject.GetComponentInParent<PauseMenu_SCRPT>().pauseMenu;
    }

    public void ResumeGame()
    {
        pausedMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync("Start Screen");
        Time.timeScale = 1;
    }
}
