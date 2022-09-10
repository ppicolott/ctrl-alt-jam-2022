using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cam : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject ladderCamera;

    void Start()
    {
        Camera.main.orthographicSize = 3f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().name.Equals("LevelFive"))
        {
            if (gameObject.name.Equals("ButtonPressure") && gameObject.GetComponent<ButtonPressure>().press)
            {
                if (collision.collider.gameObject.name.Contains("Player"))
                {
                    ladderCamera.SetActive(true);
                    mainCamera.SetActive(false);
                }
            }
            if (gameObject.name.Equals("ButtonPressure (1)") && gameObject.GetComponent<ButtonPressure>().press)
            {
                if (collision.collider.gameObject.name.Contains("Player"))
                {
                    Camera.main.orthographicSize = 8.5f;
                }
            }
        }
        else
        {
            if (gameObject.name.Contains("Button") && gameObject.GetComponent<ButtonPressure>().press)
            {
                if (collision.collider.gameObject.name.Contains("Player"))
                {
                    Camera.main.orthographicSize = 8.5f;
                }
            }
        }

        if (gameObject.name.Contains("Cam"))
        {
            if (collision.collider.gameObject.name.Contains("Player"))
            {
                Camera.main.orthographicSize = 8.5f;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().name.Equals("LevelFive"))
        {
            if (gameObject.name.Equals("ButtonPressure") && gameObject.GetComponent<ButtonPressure>().press)
            {
                mainCamera.SetActive(true);
                ladderCamera.SetActive(false);
                Camera.main.orthographicSize = 3f;
            }
            else
            {
                Camera.main.orthographicSize = 3f;
            }
        }
        else
        {
            Camera.main.orthographicSize = 3f;
        }

    }
}
