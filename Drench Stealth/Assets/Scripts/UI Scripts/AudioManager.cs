using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sorces")]

    [SerializeField] AudioSource audioSourceBackground;
    [SerializeField] AudioSource audioSourceSfx;

    [Header("Audio Clips")]

    public AudioClip background;
    public AudioClip jump;
    public AudioClip splashZone;
    public AudioClip stealthDropletIn;
    public AudioClip stealthDropletOut;
    public AudioClip boilingLift;
    public AudioClip freezingPulse;
    public AudioClip waterBottle;
    public AudioClip pressButton;
    public AudioClip death;
    public AudioClip respawn;
    public AudioClip doorOpen;
    public AudioClip victory;
    public AudioClip enemyFreezing;
    public AudioClip walking;

    private void Start()
    {
        audioSourceBackground.clip = background;
        audioSourceBackground.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        audioSourceSfx.PlayOneShot(clip);
    }
}
