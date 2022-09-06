using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HorizontalPlatform : MonoBehaviour
{
    private float damage;
    private float max;
    private float min;
    private float speed;

    private void Start()
    {
        damage = Base.damage;
        speed = 1f;
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }
    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name.Equals("LevelOne") && gameObject.name.Contains("First"))
        {
            max = 2.2f;
            min = -1;
        }
        if (SceneManager.GetActiveScene().name.Equals("LevelTwo") && gameObject.name.Contains("First"))
        {
            max = 1.8f;
            min = 0f;
        }

        if (transform.position.x > max)
        {
            GetComponent<Rigidbody2D>().velocity *= -1;
        }
        if (transform.position.x < min)
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
