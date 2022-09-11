using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderSFX : MonoBehaviour
{
    public static LadderSFX current;
    public AudioSource ladderSFX;

    private void Awake()
    {
        current = this;
    }
}
