using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    public float timer = 1f;
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 1f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 1f, 0);
        }
        if (timer <= 0)
        {
            GetComponent<Rigidbody2D>().velocity *= -1;
        }
        if(timer <= -1f)
        {
            GetComponent<Rigidbody2D>().velocity *= -1;
            timer = 1f;
        }
    }
}
