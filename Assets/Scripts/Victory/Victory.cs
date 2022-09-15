using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    [Space(10)]
    [Header("Main Controls")]
    [Space(5)]
    public static bool audioPlaying = true;

    [Space(10)]
    [Header("Button")]
    [Space(5)]
    public GameObject quitButton;

    [Space(10)]
    [Header("Language")]
    [Space(5)]
    public TextMeshProUGUI victoryText;
    public TextMeshProUGUI quitText;

    private void FixedUpdate()
    {
        CheckLanguage();

        EventSystem.current.SetSelectedGameObject(quitButton);
        if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
            Keyboard.current.spaceKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            ExitToMainMenu();
        }
    }

    private void CheckLanguage()
    {
        if (GameplayController.english)
        {
            victoryText.text = "You win!";
            quitText.text = "Back to Main Menu";
        }
        if (GameplayController.portuguese)
        {
            victoryText.text = "Vitória!";
            quitText.text = "Voltar ao Menu Inicial";
        }
    }

    public void ExitToMainMenu()
    {
        if (AudioController.current.audioSystem)
        {
            audioPlaying = true;
        }
        else
        {
            audioPlaying = true;
        }
        GameplayController.restart = true;
        SceneManager.LoadScene("MainMenu");
    }
}
