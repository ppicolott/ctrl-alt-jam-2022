using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerticalPlatform : MonoBehaviour
{
    private float damage;
    private float max;
    private float min;
    private float speed;

    private void Start()
    {
        damage = Base.damage;
        if (SceneManager.GetActiveScene().name.Equals("LevelOne"))
        {
            speed = 2.5f;
        }
        else if (SceneManager.GetActiveScene().name.Equals("LevelFour"))
        {
            speed = 0.5f;
        }
        else if (SceneManager.GetActiveScene().name.Equals("LevelFive"))
        {
            speed = 2.5f;
        }
        else
        {
            speed = 1f;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }
    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name.Equals("LevelOne") && gameObject.name.Contains("First"))
        {
            max = 3.5f;
            min = -0.5f;
        }
        if (SceneManager.GetActiveScene().name.Equals("LevelTwo") && gameObject.name.Contains("Second"))
        {
            max = 2.25f;
            min = 0f;
        }
        if (SceneManager.GetActiveScene().name.Equals("LevelFour") && gameObject.name.Contains("Second"))
        {
            max = 1.25f;
            min = -0.5f;
        }
        if (SceneManager.GetActiveScene().name.Equals("LevelFive") && gameObject.name.Contains("First"))
        {
            max = 3.5f;
            min = -1.5f;
        }
        if (SceneManager.GetActiveScene().name.Equals("LevelFive") && gameObject.name.Contains("Second"))
        {
            max = 2.3f;
            min = -1f;
        }

        if (transform.position.y > max)
        {
            GetComponent<Rigidbody2D>().velocity *= -1;
        }
        if (transform.position.y < min)
        {
            GetComponent<Rigidbody2D>().velocity *= -1;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().name.Equals("LevelOne") && gameObject.name.Contains("First"))
        {
            HUD.current.damage = damage;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        HUD.current.damage = 0;
    }
}
