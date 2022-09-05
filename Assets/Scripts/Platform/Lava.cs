using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private float damage = 0.5f;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name.Contains("Player"))
        {
            HUD.current.damage = damage;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        HUD.current.damage = 0;
    }
}
