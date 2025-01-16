using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaterShotsCounter_SCRPT : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = "x = " + GameManager.Instance.waterShots;
    }
}
