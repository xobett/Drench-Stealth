using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBar_SCRPT : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        slider.value = GameManager.Instance.waterShots;
    }
}
