using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBottleItem_SCRPT : MonoBehaviour
{
    public Animator playerAnimatorBottle;

    private AudioManager audioManager;

    public float bottleTimer;
    public float bottleTimerWaitTime;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        BottleTimer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.waterShots < 10 && GameManager.Instance.waterShots != 9)
        {
            if (collision.transform.CompareTag("Player"))
            {
                GameManager.Instance.waterShots += 2;

                playerAnimatorBottle = collision.gameObject.GetComponent<Animator>();

                playerAnimatorBottle.SetTrigger("Drink Water");

                audioManager.PlaySfx(audioManager.waterBottle);

                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = false;

                bottleTimer = bottleTimerWaitTime;
            }
        }
        else if (GameManager.Instance.waterShots < 10 && GameManager.Instance.waterShots == 9)
        {
            if (collision.transform.CompareTag("Player"))
            {
                GameManager.Instance.waterShots++;

                playerAnimatorBottle = collision.gameObject.GetComponent<Animator>();

                playerAnimatorBottle.SetTrigger("Drink Water");

                audioManager.PlaySfx(audioManager.waterBottle);

                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = false;

                bottleTimer = bottleTimerWaitTime;
            }
        }
    }

    private void BottleTimer()
    {
        bottleTimer -= Time.deltaTime;

        if (bottleTimer < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<Animator>().enabled = true;
        }
    }
}
