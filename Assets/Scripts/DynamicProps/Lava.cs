using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private float damage = 1.75f;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name.Contains("Player"))
        {
            HUD.current.damage = damage;
        }

        if (collision.collider.gameObject.name.Contains("IceCube"))
        {
            collision.collider.gameObject.transform.localScale -= new Vector3(0.001f, 0.006f, 0);
            collision.collider.gameObject.transform.Find("Steam").gameObject.SetActive(true);
            if (collision.collider.gameObject.transform.localScale.x <= 0)
            {
                Destroy(collision.collider.gameObject);
                collision.collider.gameObject.transform.Find("Steam").gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        HUD.current.damage = 0;
    }
}
