using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class AudioLangController : MonoBehaviour
{
    public static AudioLangController current;
    public AudioSource moveButton;
    public AudioSource confirmButton;
    public AudioSource cancelButton;
    public bool audioSystem = true;
    public bool restart = false;
    public bool english;
    public bool portuguese;
    public int level;

    private void Awake()
    {
        current = this;
        audioSystem = true;

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
        }
        if (restart && !Victory.audioPlaying || restart && !GameOver.audioPlaying)
        {
            audioSystem = true;
        }

        if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame ||
            Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.dpad.up.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.dpad.down.wasPressedThisFrame)
        {
            moveButton.Play();
        }

        if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
            Keyboard.current.spaceKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            confirmButton.Play();
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame || Keyboard.current.backspaceKey.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame || Mouse.current.rightButton.wasPressedThisFrame)
        {
            cancelButton.Play();
        }
    }
}
