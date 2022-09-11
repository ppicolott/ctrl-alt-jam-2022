using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlideSFX : MonoBehaviour
{
    public AudioSource slideSFX;
    public AudioSource glassSFX;
    public AudioSource meltSFX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Equals("Player"))
        {
            slideSFX.Play();
        }
        if (collision.collider.name.Contains("Cube"))
        {
            glassSFX.Play();
        }
        if (collision.collider.name.Contains("Lava"))
        {
            meltSFX.Play();
        }
    }
}