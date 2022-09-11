using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        iceLife.rectTransform.sizeDelta -= new Vector2(width, height);
    }

    private void FixedUpdate()
    {
        iceLife.rectTransform.sizeDelta = new Vector2(width * ManagerStates.life, height);
    }
}
