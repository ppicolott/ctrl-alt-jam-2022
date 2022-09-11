using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door current;
    public AudioSource doorSlidingSFX;

    private void Awake()
    {
        current = this;
    }
}
