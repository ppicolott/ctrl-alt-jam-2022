using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PresureButton : MonoBehaviour
{
    [SerializeField] private bool press;
    private void OnTriggerStay2D(Collider2D collision)
    {
        this.press = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.press = false;
    }
    public bool getPress()
    {
        return press;
    }
}
