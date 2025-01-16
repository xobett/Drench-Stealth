using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMovement_SCRPT : MonoBehaviour
{
    public Transform a;
    public Transform b;

    private Vector2 direction;

    public float raycastSpeed;


    private void Start()
    {
        Application.targetFrameRate = 60;
        direction = a.position;
    }

    void Update()
    {
        DirectionCheck();

        TranslateRaycast();
    }



    private void DirectionCheck()
    {
        if (Vector2.Distance(transform.position, a.position) < 0.1f)
        {
            direction = b.position;
        }
        else if (Vector2.Distance(transform.position, b.position) < 0.1f)
        {
            direction = a.position;
        }
    }

    private void TranslateRaycast()
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, raycastSpeed * Time.deltaTime);
    }
}
