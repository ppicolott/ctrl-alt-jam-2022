using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    private float damage;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 0);
        damage = Base.damage;
    }
    private void FixedUpdate()
    {
        if (gameObject.name.Contains("First"))
        {
            if (transform.position.x > 2f)
            {
                GetComponent<Rigidbody2D>().velocity *= -1;
            }
            if (transform.position.x < 0f)
            {
                GetComponent<Rigidbody2D>().velocity *= -1;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (gameObject.name.Contains("First"))
        {
            HUD.current.damage = damage;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        HUD.current.damage = 0;
    }
}
