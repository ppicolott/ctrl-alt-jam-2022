using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ButtonPressure : MonoBehaviour
{
    public static ButtonPressure current;
    public bool press;
    public Animator animator;
    public bool fireLaser;

    void Start()
    {
        current = this;
        this.animator = GetComponent<Animator>();
        fireLaser = false;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        this.animator.SetBool("Pressed", true);
        this.press = true;
        Pressed();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        this.animator.SetBool("Pressed", false);
        this.press = false;
        NotPressed();
    }
    public void Pressed()
    {
        if (SceneManager.GetActiveScene().name.Equals("LevelFour"))
        {
            if (gameObject.name.Equals("ButtonPressure"))
            {
                fireLaser = true;
            }
        }
        else
        {
            GameObject.Find("Door").gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Door").gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    public void NotPressed()
    {
        if (SceneManager.GetActiveScene().name.Equals("LevelFour"))
        {
            if (gameObject.name.Equals("ButtonPressure"))
            {
                fireLaser = false;
            }
        }
        else
        {
            GameObject.Find("Door").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Door").gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void PressedByLaser()
    {
        GameObject.Find("ButtonPressure (1)").gameObject.GetComponent<ButtonPressure>().animator.SetBool("Pressed", true);
        GameObject.Find("ButtonPressure (1)").gameObject.GetComponent<ButtonPressure>().press = true;
        GameObject.Find("Door").gameObject.GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Door").gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void NotPressedByLaser()
    {
        GameObject.Find("ButtonPressure (1)").gameObject.GetComponent<ButtonPressure>().animator.SetBool("Pressed", false);
        GameObject.Find("ButtonPressure (1)").gameObject.GetComponent<ButtonPressure>().press = false;
        GameObject.Find("Door").gameObject.GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Door").gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}