using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBoxSFX : MonoBehaviour
{
    public static WoodBoxSFX current;
    public AudioSource boxSlidingSFX;
    public AudioSource boxExplodingSFX;

    private void Awake()
    {
        current = this;
    }
}
