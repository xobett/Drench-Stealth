using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_SCRPT : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerDeath_SCRPT>().checkpointRespawn = transform;

            GameObject.FindGameObjectWithTag("Dead Zone").GetComponent<DeadZone_SCRPT>().checkpoint = transform;
        }
    }
}
