using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineRenderer_SCRPT : MonoBehaviour
{
    private LineRenderer line;

    public GameObject gameTarget;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        line.SetPositions(new Vector3[] {transform.position, gameTarget.transform.position});
    }
}
