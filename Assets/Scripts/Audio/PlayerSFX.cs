using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSFX : MonoBehaviour
{
    public static PlayerSFX current;
    public AudioSource jumpSFX;
    public AudioSource boilSFX;
    public AudioSource healSFX;

    private void Awake()
    {
        current = this;
    }

    void FixedUpdate()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            jumpSFX.Play();
        }
    }
}
