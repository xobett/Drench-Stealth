using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath_SCRPT : MonoBehaviour
{
    public Transform checkpointRespawn;

    private AudioManager audioManager;

    public bool playerKilled;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void EliminatePlayer()
    {
        audioManager.PlaySfx(audioManager.respawn);

        transform.position = checkpointRespawn.position;

        playerKilled = false;

        gameObject.layer = 6;

        gameObject.GetComponent<CharacterMovement_SCRPT>().moving = true;
    }

    public void MovementBlocked()
    {
        gameObject.GetComponent<CharacterMovement_SCRPT>().moving = false;
    }
}
