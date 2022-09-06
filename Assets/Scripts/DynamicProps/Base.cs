using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public static float damage = 0.05f;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name.Contains("Player"))
        {
            //damage = 0.05f;
            HUD.current.damage = damage;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        damage = 0f;
    }
}
