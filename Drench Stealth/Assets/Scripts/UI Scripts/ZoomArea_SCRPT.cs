using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomArea_SCRPT : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cinemachineCam.m_Lens.OrthographicSize = 6f;
            cinemachineCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.4f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cinemachineCam.m_Lens.OrthographicSize = 4.5f;
            cinemachineCam.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.7f;
        }
    }
}
