using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone_SCRPT : MonoBehaviour
{
    public Transform checkpoint;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            audioManager.PlaySfx(audioManager.death);

            collision.transform.position = checkpoint.position;
        }
    }
}
