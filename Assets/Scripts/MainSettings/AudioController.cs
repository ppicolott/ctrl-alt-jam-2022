using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public static AudioController current;
    public AudioSource moveButton;
    public AudioSource confirmButton;
    public AudioSource cancelButton;
    public bool audioSystem;

    private void Awake()
    {
        current = this;
        if(!GameplayController.restart)
        {
            audioSystem = true;
        }
        else
        {
            audioSystem = false;
        }
    }

    private void FixedUpdate()
    {
        if (GameplayController.restart && Victory.audioPlaying || GameplayController.restart && GameOver.audioPlaying)
        {
            audioSystem = false;
        }
        if (GameplayController.restart && !Victory.audioPlaying || GameplayController.restart && !GameOver.audioPlaying)
        {
            audioSystem = true;
        }

        if (LanguageSelector.current.languageCanvas.activeInHierarchy && !MainMenuSelector.current.canvasMainMenu.activeInHierarchy && !SettingsSelector.current.canvasSettings.activeInHierarchy ||
            MainMenuSelector.current.canvasMainMenu.activeInHierarchy && !MainMenuSelector.current.creditsImage.activeInHierarchy ||
            SettingsSelector.current.canvasSettings.activeInHierarchy && !SettingsSelector.current.gameControlsScreen.activeInHierarchy)
        {

            if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.leftArrowKey.wasPressedThisFrame ||
            Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.rightArrowKey.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.dpad.left.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.dpad.right.wasPressedThisFrame)
            {
                moveButton.Play();
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
}
