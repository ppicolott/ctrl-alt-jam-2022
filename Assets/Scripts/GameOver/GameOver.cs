using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static bool audioPlaying = true;
    public float timerKnob = 0.5f;

    [Space(10)]
    [Header("Button")]
    [Space(5)]
    public GameObject tryAgainButton;
    public GameObject quitButton;

    [Space(10)]
    [Header("Language")]
    [Space(5)]
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI tryAgainText;
    public TextMeshProUGUI quitText;

    private int selector;

    void Start()
    {
        selector = 0;
    }
    void Update()
    {
        LanguageCheck();

        if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.dpad.up.wasPressedThisFrame)
        {
            if (selector <= 0)
            {
                selector = 3;
            }
            else
            {
                selector -= 1;
            }
        }

        if (Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.downArrowKey.wasPressedThisFrame ||
             Gamepad.current != null && Gamepad.current.dpad.down.wasPressedThisFrame)
        {
            if (selector >= 1)
            {
                selector = 0;
            }
            else
            {
                selector += 1;
            }
        }

        if (selector == 0)
        {
            EventSystem.current.SetSelectedGameObject(tryAgainButton);
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
                Keyboard.current.spaceKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                Restart();
            }
        }
        else if (selector == 1)
        {
            EventSystem.current.SetSelectedGameObject(quitButton);
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
                Keyboard.current.spaceKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                ExitToMainMenu();
            }
        }
    }
    public void LanguageCheck()
    {
        if (AudioLangController.current.english)
        {
            titleText.text = "Game Over";
            tryAgainText.text = "Try again";
            quitText.text = "Back to Main Menu";
        }
        else if (AudioLangController.current.portuguese)
        {
            titleText.text = "Fim de Jogo";
            tryAgainText.text = "Tente novamente";
            quitText.text = "Voltar ao Menu Inicial";
        }
    }
    public void Restart()
    {
        switch (AudioLangController.current.level)
        {
            case 1:
                SceneManager.LoadScene("LevelOne");
                break;
            case 2:
                SceneManager.LoadScene("LevelTwo");
                break;
            case 3:
                SceneManager.LoadScene("LevelThree");
                break;
            case 4:
                SceneManager.LoadScene("LevelFour");
                break;
            case 5:
                SceneManager.LoadScene("LevelFive");
                break;
            case 6:
                SceneManager.LoadScene("LevelSix");
                break;
        }
    }
    public void ExitToMainMenu()
    {
        if (AudioLangController.current.audioSystem)
        {
            audioPlaying = true;
        }
        else
        {
            audioPlaying = true;
        }
        AudioLangController.current.restart = true;
        SceneManager.LoadScene("MainMenu");
    }
}
