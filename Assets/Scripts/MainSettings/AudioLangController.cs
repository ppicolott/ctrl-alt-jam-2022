using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioLangController : MonoBehaviour
{
    public static AudioLangController current;
    public static AudioSource audioSource;
    public bool audioSystem = true;
    public bool restart = false;
    public bool english;
    public bool portuguese;
    public int level;

    public int level = 1;

    private void Awake()
    {
        current = this;
        audioSystem = true;
        audioSource = GetComponent<AudioSource>();
        // audioSource.Play();

        if (SceneManager.GetActiveScene().name.Contains("One"))
        {
            level = 1;
        }
        if (SceneManager.GetActiveScene().name.Contains("Two"))
        {
            level = 2;
        }
        if (SceneManager.GetActiveScene().name.Contains("Three"))
        {
            level = 3;
        }
        if (SceneManager.GetActiveScene().name.Contains("Four"))
        {
            level = 4;
        }
        if (SceneManager.GetActiveScene().name.Contains("Five"))
        {
            level = 5;
        }
        if (SceneManager.GetActiveScene().name.Contains("Six"))
        {
            level = 6;
        }
    }

    private void FixedUpdate()
    {
        if (restart && Victory.audioPlaying || restart && GameOver.audioPlaying)
        {
            audioSystem = false;
            audioSource.Stop();
        }
        if (restart && !Victory.audioPlaying || restart && !GameOver.audioPlaying)
        {
            audioSystem = true;
            audioSource.Stop();
        }
    }
}
