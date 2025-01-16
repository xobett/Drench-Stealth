using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilingCloud_SCRPT : MonoBehaviour
{
    #region Move Variables

    public Transform A;

    public float speedCloud;

    #endregion

    #region Timer 

    private float timerCloud;
    public float waitTimeCloud;

    #endregion

    #region Destroy Cloud Timer

    private float destroyCloudTimer;
    public float destroyCloudWaitTime;

    #endregion

    private Animator cloudAnimator;

    private void Start()
    {
        timerCloud = waitTimeCloud;

        destroyCloudTimer = destroyCloudWaitTime;

        cloudAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        CloudTimer();

        DestroyCloudTimer();
    }

    private void CloudTimer()
    {
        timerCloud -= Time.deltaTime;

        if (timerCloud < 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, A.position, speedCloud * Time.deltaTime);
        }
    }

    private void DestroyCloudTimer()
    {
        destroyCloudTimer -= Time.deltaTime;

        if (destroyCloudTimer < 0)
        {
            cloudAnimator.SetTrigger("Evaporate Cloud");
        }
    }

    private void EvaporateCloud()
    {
        Destroy(transform.parent.gameObject);
    }
}
