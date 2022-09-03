using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 1f, 0);
    }
    private void FixedUpdate()
    {
        if(transform.position.y >= 1f)
        {
            GetComponent<Rigidbody2D>().velocity *= -1;
        }
        if(transform.position.y <= -0.15f)
        {
            GetComponent<Rigidbody2D>().velocity *= -1;
        }
    }
}
