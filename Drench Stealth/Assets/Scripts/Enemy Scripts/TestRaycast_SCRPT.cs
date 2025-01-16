using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRaycast_SCRPT : MonoBehaviour
{
    public GameObject target;
    public GameObject playerPf;

    public Transform spawnpoint;

    private AudioManager audioManager;

    private bool testRay = false;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, target.transform.position - transform.position);

        if (ray.collider != null)
        {
            testRay = ray.collider.CompareTag("Player");

            if (testRay)
            {
                if (ray.collider.gameObject.layer == 6)
                {
                    Animator playerAnimator = ray.collider.gameObject.GetComponent<Animator>();

                    playerAnimator.SetTrigger("Death");

                    audioManager.PlaySfx(audioManager.death);

                    ray.collider.gameObject.GetComponent<PlayerDeath_SCRPT>().playerKilled = true;

                    ray.collider.gameObject.layer = 10;
                }
            }
        }
    }
}
