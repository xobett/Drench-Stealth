using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision_SCRPT : MonoBehaviour
{
    private Rigidbody2D waterRb;

    private Animator puddleAnimator;

    private bool touchedGround;

    private void Start()
    {
        waterRb = GetComponent<Rigidbody2D>();

        puddleAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3 && collision.gameObject.CompareTag("Ground"))
        {
            puddleAnimator.SetBool("isTouching", true);
            waterRb.constraints = RigidbodyConstraints2D.FreezeAll;

            touchedGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water Puddle") && touchedGround)
        {
            puddleAnimator.SetTrigger("Evaporate Puddle");

            gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
        }
    }

    private void EvaporatePuddle()
    {
        Destroy(this.transform.parent.gameObject);
    }

    private void DisableColliders()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void EnableColliders()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
