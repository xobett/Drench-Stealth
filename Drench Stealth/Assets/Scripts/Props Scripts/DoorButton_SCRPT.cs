using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton_SCRPT : MonoBehaviour
{
    public bool pressButtonCheck;
    public bool doorOpened;
    public bool playerHiding;
    public bool enemyTouching;

    public float enemyPressTimer;

    private Animator buttonAnimator;
    private Animator playerAnimatorButton;

    private AudioManager audioManager;

    private void Start()
    {
        enemyPressTimer = 3f;

        buttonAnimator = GetComponent<Animator>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        PressButton();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pressButtonCheck = true;

            playerAnimatorButton = collision.GetComponent<Animator>();

            playerAnimatorButton.SetBool("isPressing", true);
        }

        if (collision.CompareTag("Enemy"))
        {
            bool enemyUnfreezed = collision.GetComponent<EnemyMovement_SCRPT>().enemyMoving;

            if (!enemyUnfreezed)
            {
                enemyPressTimer -= Time.deltaTime;

                EnemyPressButton();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pressButtonCheck = false;

            playerAnimatorButton.SetBool("isPressing", false);
        }

        if (collision.CompareTag("Enemy"))
        {
            enemyTouching = false;
        }
    }

    private void PressButton()
    {
        if (pressButtonCheck)
        {
            if (!playerHiding)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    playerAnimatorButton.SetTrigger("Press Button");

                    audioManager.PlaySfx(audioManager.pressButton);

                    buttonAnimator.SetBool("isPressed", true);

                    doorOpened = true;
                }
            }
        }
    }

    private void EnemyPressButton()
    {
        if (!doorOpened && enemyPressTimer < 0)
        {
            audioManager.PlaySfx(audioManager.pressButton);

            buttonAnimator.SetBool("isPressed", true);

            doorOpened = true;
        }
    }

    private void VariableCheck()
    {
        playerHiding = GameObject.FindGameObjectWithTag("Player").GetComponent<StealthDroplet_SCRPT>().isHiding;
    }
}
