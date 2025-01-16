using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu_SCRPT : MonoBehaviour
{
    public GameObject pauseMenu;

    void Update()
    {
        PauseGame();
    }

    private void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
