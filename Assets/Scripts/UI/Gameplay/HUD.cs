using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD current;
    public Image iceLife;
    public float damage;
    public float width;
    private float height;

    private void Start()
    {
        current = this;
        width = 400f;
        height = 50f;
        iceLife.rectTransform.sizeDelta -= new Vector2(width, height);
    }

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name.Contains("One"))
        {
            GameplayController.level = 1;
        }
        if (SceneManager.GetActiveScene().name.Contains("Two"))
        {
            GameplayController.level = 2;
        }
        if (SceneManager.GetActiveScene().name.Contains("Three"))
        {
            GameplayController.level = 3;
        }
        if (SceneManager.GetActiveScene().name.Contains("Four"))
        {
            GameplayController.level = 4;
        }
        if (SceneManager.GetActiveScene().name.Contains("Five"))
        {
            GameplayController.level = 5;
        }
        if (SceneManager.GetActiveScene().name.Contains("Six"))
        {
            GameplayController.level = 6;
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame || Keyboard.current.backspaceKey.wasPressedThisFrame ||
            Gamepad.current != null && Gamepad.current.buttonEast.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonNorth.wasPressedThisFrame)
        {
            BackToMainMenu();
        }

        if(width <= 400 && width > 0)
        {
            width -= damage;
        }
        iceLife.rectTransform.sizeDelta = new Vector2(width * GameplayController.life, height);
    }

    public void RetryLevel()
    {
        switch (GameplayController.level)
        {
            case 1:
                SceneManager.LoadScene("LevelOne");
                GameplayController.life = 1f;
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

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
