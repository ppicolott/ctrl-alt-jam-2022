using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;

public class SettingsSelector : MonoBehaviour
{
    public static SettingsSelector current;

    private int selector;

    [Space(10)]
    [Header("Settings Screen")]
    [Space(5)]
    public GameObject settingsScreen;
    public GameObject gameControlsButton;
    public GameObject languageButton;
    public GameObject audioButton;
    public GameObject backButton;

    [Space(5)]
    [Header("Language - Settings Screen")]
    [Space(5)]
    public TextMeshProUGUI title;
    public TextMeshProUGUI gameControlsText;
    public TextMeshProUGUI languageText;
    public TextMeshProUGUI languageTitleText;
    public TextMeshProUGUI audioText;
    public TextMeshProUGUI audioTitleText;
    public TextMeshProUGUI backText;

    [Space(10)]
    [Header("Controls Screen")]
    [Space(5)]
    public GameObject gameControlsScreen;

    [Space(5)]
    [Header("Language - Controls Screen")]
    [Space(5)]
    public TextMeshProUGUI titleControl;
    public TextMeshProUGUI jumpText;
    public TextMeshProUGUI moveText;
    public TextMeshProUGUI backControlText;

    [Space(10)]
    [Header("Settings")]
    [Space(5)]
    public GameObject canvasMainMenu;
    public GameObject canvasSettings;

    void Start()
    {
        current = this;

        selector = 0;

        CheckLanguage();
    }
    public void PointerOn()
    {
        EventSystem.current.SetSelectedGameObject(null);
        selector = -1;
    }

    void Update()
    {
        CheckLanguage();

        if (canvasSettings.activeInHierarchy && !gameControlsScreen.activeInHierarchy)
        {
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
                if (selector >= 3)
                {
                    selector = 0;
                }
                else
                {
                    selector += 1;
                }
            }
        }

        if(selector == 0)
        {
            EventSystem.current.SetSelectedGameObject(gameControlsButton);
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
                Keyboard.current.spaceKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                GameControlsButton();
            }
        }
        else if (selector == 1)
        {
            EventSystem.current.SetSelectedGameObject(languageButton);
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
                Keyboard.current.spaceKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                LanguageButton();
            }
        }
        else if (selector == 2)
        {
            EventSystem.current.SetSelectedGameObject(audioButton);
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
                Keyboard.current.spaceKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                AudioButton();
            }
        }
        else if (selector == 3)
        {
            EventSystem.current.SetSelectedGameObject(backButton);
            if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame ||
                Keyboard.current.spaceKey.wasPressedThisFrame ||
                Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
            {
                BackToMainMenu();
            }
        }

        if(Keyboard.current.anyKey.wasPressedThisFrame ||
            Mouse.current.rightButton.wasPressedThisFrame ||
            Mouse.current.leftButton.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.buttonWest.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.buttonNorth.wasPressedThisFrame)
        {
            BackFromControlsScreen();
        }
    }

    public void CheckLanguage()
    {
        if (GameplayController.english)
        {
            title.text = "Settings";
            gameControlsText.text = "Game Controls";
            languageText.text = "English";
            languageTitleText.text = "Language";
            audioTitleText.text = "Audio";
            if (AudioController.current.audioSystem)
            {
                audioText.text = "On";
                AudioListener.volume = 1;
            }
            else if (!AudioController.current.audioSystem)
            {
                audioText.text = "Off";
                AudioListener.volume = 0;
            }
            backText.text = "Back to Main Menu";
        }
        else if (GameplayController.portuguese)
        {
            title.text = "Op??es";
            gameControlsText.text = "Controles do Jogo";
            languageText.text = "Portugu?s";
            languageTitleText.text = "Linguagem";
            audioTitleText.text = "?udio";
            if (AudioController.current.audioSystem)
            {
                audioText.text = "Ligado";
                AudioListener.volume = 1;
            }
            else if (!AudioController.current.audioSystem)
            {
                audioText.text = "Desligado";
                AudioListener.volume = 0;
            }
            backText.text = "Voltar ao Menu Inicial";
        }
    }

    public void GameControlsButton()
    {
        gameControlsButton.SetActive(false);
        gameControlsScreen.SetActive(true);
        settingsScreen.SetActive(false);
        if (GameplayController.english)
        {
            titleControl.text = "Controls";
            jumpText.text = "Jump";
            moveText.text = "Move";
            backControlText.text = "Back to Settings Menu";
        }
        else if(GameplayController.portuguese)
        {
            titleControl.text = "Controles";
            jumpText.text = "Pular";
            moveText.text = "Movimentar";
            backControlText.text = "Voltar ao Menu de Op??es";
        }
        languageButton.SetActive(false);
        audioButton.SetActive(false);
        backButton.SetActive(false);
    }

    public void LanguageButton()
    {
        if (GameplayController.english)
        {
            GameplayController.english = false;
            GameplayController.portuguese = true;
        }
        else if (GameplayController.portuguese)
        {
            GameplayController.english = true;
            GameplayController.portuguese = false;
        }
    }

    public void AudioButton()
    {
        EventSystem.current.SetSelectedGameObject(audioButton);
        if(AudioController.current.audioSystem)
        {
            AudioController.current.audioSystem = false;
        }
        else if(!AudioController.current.audioSystem)
        {
            AudioController.current.audioSystem = true;
        }
    }

    public void BackFromControlsScreen()
    {
        settingsScreen.SetActive(true);
        gameControlsButton.SetActive(true);
        gameControlsScreen.SetActive(false);
        languageButton.SetActive(true);
        audioButton.SetActive(true);
        backButton.SetActive(true);
    }
    public void BackToMainMenu()
    {
        canvasSettings.SetActive(false);
        canvasMainMenu.SetActive(true);
    }
}
