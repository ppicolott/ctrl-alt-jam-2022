using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private float damage;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1f);
        damage = Base.damage;
    }
    private void FixedUpdate()
    {
        if (gameObject.name.Contains("Second"))
        {
            if (transform.position.y > 2.5f)
            {
                GetComponent<Rigidbody2D>().velocity *= -1;
            }
            if (transform.position.y < 0f)
            {
                GetComponent<Rigidbody2D>().velocity *= -1;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (gameObject.name.Contains("Second"))
        {
            HUD.current.damage = damage;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        HUD.current.damage = 0;
    }
}
