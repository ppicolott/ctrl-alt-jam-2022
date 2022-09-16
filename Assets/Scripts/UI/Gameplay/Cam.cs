using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class Cam : MonoBehaviour
{
    public Transform ladderCamera;

    private bool isZoomOut = false;
    private bool isMove = false;

    void Start()
    {
        Camera.main.orthographicSize = 3f;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (SceneManager.GetActiveScene().name.Equals("LevelFive"))
        {
            if (gameObject.name.Equals("ButtonPressure"))
            {
                if (collider.gameObject.tag.Contains("Player"))
                {
                    StartCoroutine(MoveToPoint(ladderCamera.position));
                    StartCoroutine(ZoomOut(5f));
                }
            }
            if (gameObject.name.Equals("ButtonPressure (1)"))
            {
                if (collider.gameObject.tag.Contains("Player"))
                {
                    StartCoroutine(ZoomOut(8.5f));
                }
            }
        }
        else
        {
            if (gameObject.name.Contains("Button"))
            {
                if (collider.gameObject.tag.Contains("Player"))
                {
                    StartCoroutine(ZoomOut(8.5f));
                }
            }
        }

        if (gameObject.name.Contains("Cam"))
        {
            if (collider.gameObject.tag.Contains("Player"))
            {
                StartCoroutine(ZoomOut(8.5f));
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name.Equals("LevelFive"))
        {
            if (gameObject.name.Equals("ButtonPressure"))
            {
                StartCoroutine(MoveToStart());
                StartCoroutine(ZoomIn(3f));
            }
            else
            {
                StartCoroutine(ZoomIn(3f));
            }
        }
        else
        {
            StartCoroutine(ZoomIn(3f));
        }

    }
    private IEnumerator ZoomOut(float value)
    {
        isZoomOut = true;
        while (Camera.main.orthographicSize < value)
        {
            Camera.main.orthographicSize += 0.1f;
            yield return new WaitForSeconds(Time.deltaTime);
            if (!isZoomOut)
            {
                break;
            }
        }
    }
    private IEnumerator ZoomIn(float value)
    {
        isZoomOut = false;
        while (Camera.main.orthographicSize > value)
        {
            Camera.main.orthographicSize -= 0.1f;
            yield return new WaitForSeconds(Time.deltaTime);
            if (isZoomOut)
            {
                break;
            }
        }
    }
    private IEnumerator MoveToPoint(Vector3 pos)
    {
        bool directionHorizontal = Camera.main.transform.position.x < pos.x;
        bool directionVertical = Camera.main.transform.position.y < pos.y;
        isMove = true;
        while ((directionHorizontal ? Camera.main.transform.position.x < pos.x : Camera.main.transform.position.x > pos.x) || (directionVertical ? Camera.main.transform.position.y < pos.y : Camera.main.transform.position.y > pos.y))
        {
            float directionHorizontalSpeed = 0f;
            float directionVerticalSpeed = 0f;
            if (directionHorizontal ? Camera.main.transform.position.x < pos.x : Camera.main.transform.position.x > pos.x)
            {
                directionHorizontalSpeed = directionHorizontal ? 0.1f : -0.1f;
            }
            if (directionVertical ? Camera.main.transform.position.y < pos.y : Camera.main.transform.position.y > pos.y)
            {
                directionVerticalSpeed = directionVertical ? 0.1f : -0.1f;
            }
            Camera.main.transform.position += new Vector3(directionHorizontalSpeed, directionVerticalSpeed, 0f);
            yield return new WaitForSeconds(Time.deltaTime / 2);
            if (!isMove)
            {
                break;
            }
        }
        Camera.main.transform.position = new Vector3(pos.x, pos.y, Camera.main.transform.localPosition.z);
    }
    private IEnumerator MoveToStart()
    {
        Vector3 pos = Vector3.zero;
        bool directionHorizontal = Camera.main.transform.localPosition.x < pos.x;
        bool directionVertical = Camera.main.transform.localPosition.y < pos.y;
        isMove = false;
        while ((directionHorizontal ? Camera.main.transform.localPosition.x < pos.x : Camera.main.transform.localPosition.x > pos.x) || (directionVertical ? Camera.main.transform.localPosition.y < pos.y : Camera.main.transform.localPosition.y > pos.y))
        {
            float directionHorizontalSpeed = 0f;
            float directionVerticalSpeed = 0f;
            if (directionHorizontal ? Camera.main.transform.localPosition.x < pos.x : Camera.main.transform.localPosition.x > pos.x)
            {
                directionHorizontalSpeed = directionHorizontal ? 0.1f : -0.1f;
            }
            if (directionVertical ? Camera.main.transform.localPosition.y < pos.y : Camera.main.transform.localPosition.y > pos.y)
            {
                directionVerticalSpeed = directionVertical ? 0.1f : -0.1f;
            }
            Camera.main.transform.localPosition += new Vector3(directionHorizontalSpeed, directionVerticalSpeed, 0f);
            yield return new WaitForSeconds(Time.deltaTime / 4);
            if (isMove)
            {
                break;
            }
        }
        Camera.main.transform.localPosition = new Vector3(pos.x, pos.y, Camera.main.transform.localPosition.z);
    }
}
