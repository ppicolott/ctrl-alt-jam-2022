using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    public static Laser current;
    public Transform firePoint;
    public LineRenderer lineRenderer;
    private RaycastHit2D[] targetPoint;
    private float distance;
    private float levelFourAngle;
    private float levelFiveAngle;


    private void Start()
    {
        lineRenderer.sortingOrder = -1;
        distance = 7.5f;
        levelFourAngle = 1.65f;
        levelFiveAngle = 4.5f;
    }

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name.Equals("LevelFour"))
        {
            if (GameObject.Find("ButtonPressure").GetComponent<ButtonPressure>().press)
            {
                FireLaser();
                InvokeRepeating("LineTwinkle", 0.02f, 0.02f);
                LaserSFX.current.laserAudio.gameObject.SetActive(true);
            }
            if (!GameObject.Find("ButtonPressure").GetComponent<ButtonPressure>().press)
            {
                ButtonPressure.current.NotPressedByLaser();
                CancelInvoke();
                lineRenderer.enabled = false;
                LaserSFX.current.laserAudio.gameObject.SetActive(false);
            }
        }

        if (SceneManager.GetActiveScene().name.Equals("LevelFive"))
        {
            if (GameObject.Find("ButtonPressure (1)").GetComponent<ButtonPressure>().press)
            {
                FireLaser();
                InvokeRepeating("LineTwinkle", 0.02f, 0.02f);
                LaserSFX.current.laserAudio.gameObject.SetActive(true);
            }
            if (!GameObject.Find("ButtonPressure (1)").GetComponent<ButtonPressure>().press)
            {
                ButtonPressure.current.NotPressedByLaser();
                CancelInvoke();
                lineRenderer.enabled = false;
                LaserSFX.current.laserAudio.gameObject.SetActive(false);
            }
        }
    }

    private void FireLaser()
    {
        targetPoint = Physics2D.RaycastAll(firePoint.position, firePoint.up);

        lineRenderer.sortingOrder = 5;

        for (int i = 0; i < targetPoint.Length; i++)
        {
            RaycastHit2D hit = targetPoint[i];

            if (hit)
            {
                if (SceneManager.GetActiveScene().name.Equals("LevelFour"))
                {
                    lineRenderer.SetPosition(0, firePoint.position);
                    lineRenderer.SetPosition(1, new Vector2(firePoint.position.x + (distance * -1), firePoint.position.y + levelFourAngle));

                    if (hit.collider.gameObject.name.Equals("ButtonPressure (1)"))
                    {
                        ButtonPressure.current.PressedByLaser();
                    }
                }

                if (SceneManager.GetActiveScene().name.Equals("LevelFive"))
                {
                    lineRenderer.SetPosition(0, firePoint.position);
                    lineRenderer.SetPosition(1, new Vector2(firePoint.position.x + (distance), firePoint.position.y + levelFiveAngle));

                    if (hit.collider.gameObject.name.Equals("ButtonPressure (2)"))
                    {
                        ButtonPressure.current.PressedByLaser();
                    }
                }

                if (hit.collider.gameObject.name.Contains("Box") || hit.collider.gameObject.name.Contains("Cube"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    private void LineTwinkle()
    {
        if(lineRenderer != null)
        {
            lineRenderer.enabled =! lineRenderer.enabled;
        }
    }
}
