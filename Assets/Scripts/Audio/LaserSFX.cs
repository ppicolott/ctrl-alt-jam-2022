using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSFX : MonoBehaviour
{
    public static LaserSFX current;
    public AudioSource laserAudio;
    private float audioOscillation;

    private void Awake()
    {
        current = this;

        laserAudio = GameObject.Find("LaserSFX").GetComponent<AudioSource>();
        laserAudio.gameObject.SetActive(false);
        laserAudio.loop = true;
        laserAudio.volume = 0.65f;
        laserAudio.panStereo = -1f;

        audioOscillation = 0.05f;
    }

    void FixedUpdate()
    {
        laserAudio.panStereo += audioOscillation;
        if (laserAudio.panStereo == 1)
        {
            audioOscillation *= -1;
        }
        else if (laserAudio.panStereo == -1)
        {
            audioOscillation *= -1;
        }
    }
}
