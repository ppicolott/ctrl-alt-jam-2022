using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] private float Effect;
    private Transform cam;
    private float length;
    private float startPosition;
    // Start is called before the first frame update
    void Start()
    {
        this.startPosition = transform.position.x + GetComponent<SpriteRenderer>().bounds.size.x / 2;
        this.length = GetComponent<SpriteRenderer>().bounds.size.x;
        this.cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(this.startPosition + (this.cam.transform.position.x * this.Effect), transform.position.y, transform.position.z);
    }
}
