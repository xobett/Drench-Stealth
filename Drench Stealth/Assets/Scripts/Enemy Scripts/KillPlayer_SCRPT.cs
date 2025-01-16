using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer_SCRPT : MonoBehaviour
{
    private bool enemyFreezed;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        FreezeCheck();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.transform.CompareTag("Player") && !enemyFreezed)
       {
            Animator playerAnimator = collision.gameObject.GetComponent<Animator>();

            playerAnimator.SetTrigger("Death");

            audioManager.PlaySfx(audioManager.death);

            collision.gameObject.GetComponent<PlayerDeath_SCRPT>().playerKilled = true;

            collision.gameObject.layer = 10;
       } 
    }

    private void FreezeCheck()
    {
        enemyFreezed = gameObject.GetComponent<EnemyMovement_SCRPT>().enemyUnfreezed;
    }

}
