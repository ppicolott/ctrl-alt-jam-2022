using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    void Start()
    {
        Camera.main.orthographicSize = 3f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(gameObject.name.Contains("Button") && ButtonPressure.current.press)
        {
            if (collision.collider.gameObject.name.Contains("Player"))
            {
                Camera.main.orthographicSize = 7.5f;
            }
        }
        if (gameObject.name.Contains("Cam"))
        {
            if (collision.collider.gameObject.name.Contains("Player"))
            {
                Camera.main.orthographicSize = 7.5f;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Camera.main.orthographicSize = 3f;
    }
}
