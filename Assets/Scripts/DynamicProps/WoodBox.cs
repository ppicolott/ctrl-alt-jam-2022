using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBox : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name.Equals("Player") && transform.position.x != 0)
        {
            WoodBoxSFX.current.boxSlidingSFX.Play();
            WoodBoxSFX.current.boxSlidingSFX.loop = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("Player"))
        {
            WoodBoxSFX.current.boxSlidingSFX.Stop();
        }
    }
}
