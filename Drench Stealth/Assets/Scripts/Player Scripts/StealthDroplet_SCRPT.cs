using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthDroplet_SCRPT : MonoBehaviour
{
    #region Hiding Detection

    public bool isHiding;
    public bool isMoving;
    public bool stoppedHiding;

    #endregion

    #region Water Detection

    public bool waterCheck;

    #endregion

    #region Timer Variables

    public float waitTime;
    public float timer;

    #endregion

    private Animator animator;

    private AudioManager audioManager;

    private void Start()
    {
        animator = GetComponent<Animator>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        ActivateStealth();

        StoppedHidingTimer();
    }

    private void StoppedHidingTimer()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            stoppedHiding = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            waterCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            waterCheck = false;
        }
    }

    private void ActivateStealth()
    {
        if (waterCheck)
        {
            if(Input.GetKeyDown(KeyCode.Q) && gameObject.GetComponent<CharacterMovement_SCRPT>().hor == 0)
            {
                isHiding = true;

                animator.SetBool("inStealthDroplet", true);

                audioManager.PlaySfx(audioManager.stealthDropletIn);
            }

            if (isHiding)
            {
                Hide(); 
            }
        }
    }

    private void Hide()
    {
        gameObject.layer = 7;

        if (Input.GetKeyDown(KeyCode.R))
        {
            StopHiding();

            animator.SetBool("inStealthDroplet", false);

            audioManager.PlaySfx(audioManager.stealthDropletOut);
        }
    }

    private void StopHiding()
    {
        isHiding = false;
        stoppedHiding = true;

        gameObject.layer = 6;

        timer = waitTime;
    }
}
