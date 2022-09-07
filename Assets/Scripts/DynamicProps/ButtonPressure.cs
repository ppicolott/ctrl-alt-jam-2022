using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ButtonPressure : MonoBehaviour
{
    public static ButtonPressure current;
    public bool press;
    private Animator animator;
    void Start()
    {
        current = this;
        this.animator = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        this.animator.SetBool("Pressed", true);
        this.press = true;
        Pressed();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.animator.SetBool("Pressed", false);
        this.press = false;
        NotPressed();
    }
    public void Pressed()
    {
        GameObject.Find("Door").gameObject.GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Door").gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void NotPressed()
    {
        GameObject.Find("Door").gameObject.GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Door").gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}