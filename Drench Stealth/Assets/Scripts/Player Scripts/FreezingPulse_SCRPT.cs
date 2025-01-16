using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingPulse_SCRPT : MonoBehaviour
{
    private Animator playerAnimator;
    private Animator puddleAnimatorFreezing;

    private AudioManager audioManager;

    public bool freeze;
    public bool playerHiding;
    public bool playerIsDead;

    public float timerFreezing;
    public float waitTimeFreezing;

    private void Start()
    {
        puddleAnimatorFreezing = transform.parent.gameObject.GetComponent<Animator>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        FreezingTimer();

        FreezeEnemy();

        VariablesCheck();
    }

    private void FreezeEnemy()
    {
        if (!playerIsDead)
        {
            if (!playerHiding)
            {
                if (Input.GetKeyDown(KeyCode.O))
                {
                    playerAnimator.SetTrigger("FreezingPulse");

                    audioManager.PlaySfx(audioManager.freezingPulse);

                    freeze = true;
                    timerFreezing = waitTimeFreezing;
                }
            }
        }
    }

    private void FreezingTimer()
    {
        timerFreezing -= Time.deltaTime;

        if (timerFreezing < 0 )
        {
            freeze = false;
        }
    }

    private void OnTriggerStay2D(Collider2D enemy)
    {
        if (freeze)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<EnemyMovement_SCRPT>().FreezedMovement();

                puddleAnimatorFreezing.SetTrigger("Evaporate Puddle");
            }
        }
    }

    private void VariablesCheck()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        playerHiding = GameObject.FindGameObjectWithTag("Player").GetComponent<StealthDroplet_SCRPT>().isHiding;
        playerIsDead = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath_SCRPT>().playerKilled;
    }
}
