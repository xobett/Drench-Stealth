using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleStealthAnimation_SCRPT : MonoBehaviour
{
    private bool playerIsHiding;

    private Animator puddleAnimator;

    private void Start()
    {
        puddleAnimator = GetComponentInParent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsHiding = collision.gameObject.GetComponent<StealthDroplet_SCRPT>().isHiding;
            
            if (playerIsHiding)
            {
                puddleAnimator.SetBool("playerIsHiding", true);
            }
            else
            {
                puddleAnimator.SetBool("playerIsHiding", false);
            }
        }
    }
}
