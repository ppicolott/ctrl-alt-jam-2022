using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public AudioSource doorSlidingSFX;
    private bool doorSpriteEnabled;

    private void Start()
    {
        doorSpriteEnabled = GetComponentInChildren<SpriteRenderer>().enabled;
    }

    private void FixedUpdate()
    {
        if(GetComponentInChildren<SpriteRenderer>().enabled != doorSpriteEnabled)
        {
            doorSlidingSFX.Play();
            doorSpriteEnabled = GetComponentInChildren<SpriteRenderer>().enabled;
        }
    }
}
