using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ButtonPressure : MonoBehaviour
{
    private bool press;
    private Animator animator;
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        this.animator.SetBool("Pressed", true);
        this.press = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.animator.SetBool("Pressed", false);
        this.press = false;
    }
    public bool getPress()
    {
        return press;
    }
}
