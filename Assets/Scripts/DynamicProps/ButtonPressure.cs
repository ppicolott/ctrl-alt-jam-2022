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

    void Start()
    {
        current = this;
        this.animator = GetComponent<Animator>();
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
        Door.current.doorSlidingSFX.Play();

        if (SceneManager.GetActiveScene().name.Equals("LevelThree"))
        {
            GameObject.Find("Door").gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Door").gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (SceneManager.GetActiveScene().name.Equals("LevelFive"))
        {
            if (gameObject.name.Equals("ButtonPressure"))
            {
                GameObject.Find("Door (1)").gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Door (1)").gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            if (gameObject.name.Equals("ButtonPressure (2)"))
            {
                GameObject.Find("Door").gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Door").gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
    public void NotPressed()
    {
        if (SceneManager.GetActiveScene().name.Equals("LevelThree"))
        {
            GameObject.Find("Door").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Door").gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (SceneManager.GetActiveScene().name.Equals("LevelFive"))
        {
            GameObject.Find("Door (1)").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Door (1)").gameObject.GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("Door").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Door").gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        Door.current.doorSlidingSFX.Play();
    }

    public void PressedByLaser()
    {
        Door.current.doorSlidingSFX.Play();

        if (SceneManager.GetActiveScene().name.Equals("LevelFour"))
        {
            GameObject.Find("ButtonPressure (1)").gameObject.GetComponent<ButtonPressure>().animator.SetBool("Pressed", true);
            GameObject.Find("ButtonPressure (1)").gameObject.GetComponent<ButtonPressure>().press = true;
            GameObject.Find("Door").gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Door").gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (SceneManager.GetActiveScene().name.Equals("LevelFive"))
        {
            GameObject.Find("ButtonPressure (2)").gameObject.GetComponent<ButtonPressure>().animator.SetBool("Pressed", true);
            GameObject.Find("ButtonPressure (2)").gameObject.GetComponent<ButtonPressure>().press = true;
            GameObject.Find("Door").gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Door").gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void NotPressedByLaser()
    {
        if (SceneManager.GetActiveScene().name.Equals("LevelFour"))
        {
            GameObject.Find("ButtonPressure (1)").gameObject.GetComponent<ButtonPressure>().animator.SetBool("Pressed", false);
            GameObject.Find("ButtonPressure (1)").gameObject.GetComponent<ButtonPressure>().press = false;
            GameObject.Find("Door").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Door").gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (SceneManager.GetActiveScene().name.Equals("LevelFive"))
        {
            GameObject.Find("ButtonPressure (2)").gameObject.GetComponent<ButtonPressure>().animator.SetBool("Pressed", false);
            GameObject.Find("ButtonPressure (2)").gameObject.GetComponent<ButtonPressure>().press = false;
            GameObject.Find("Door").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Door").gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        Door.current.doorSlidingSFX.Play();
    }
}