using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedPath_SCRPT : MonoBehaviour
{
    public GameObject button;

    private Animator doorAnimator;

    private AudioManager audioManager;

    private bool doorOpened;

    private void Start()
    {
        doorAnimator = GetComponent<Animator>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        ButtonCheck();
        OpenPath();
    }

    private void ButtonCheck()
    {
        doorOpened = button.GetComponentInChildren<DoorButton_SCRPT>().doorOpened;
    }

    private void OpenPath()
    {
        if (doorOpened)
        {
            doorAnimator.SetBool("doorIsOpened", true);

            //audioManager.PlaySfx(audioManager.doorOpen);

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
