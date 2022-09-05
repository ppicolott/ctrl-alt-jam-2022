using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD current;
    public Image iceLife;
    public float damage;
    private float width;
    private float height;

    private void Start()
    {
        current = this;
        width = 400f;
        height = 50f;
        damage = 0f;
        iceLife.rectTransform.sizeDelta -= new Vector2(width, height);
    }

    private void FixedUpdate()
    {
        if(width > 0 && damage > 0)
        {
            width -= damage;
        }
        if(width < 400f && damage < 0)
        {
            width -= damage;
        }
        iceLife.rectTransform.sizeDelta = new Vector2(width, height);
    }
}
