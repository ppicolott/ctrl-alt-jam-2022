using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Laser : MonoBehaviour
{
    public static Laser current;
    public Transform firePoint;
    public LineRenderer lineRenderer;
    private RaycastHit2D[] targetPoint;
    private float distance;
    private float levelFourAngle;

    private void Start()
    {
        lineRenderer.sortingOrder = -1;
        distance = 7.5f;
        levelFourAngle = 1.65f;
    }

    private void FixedUpdate()
    {
        if(ButtonPressure.current.fireLaser)
        {
            StartCoroutine(LaserBeam());
        }
        else
        {
            ButtonPressure.current.NotPressedByLaser();
        }

    }

    public IEnumerator LaserBeam()
    {
        targetPoint = Physics2D.RaycastAll(firePoint.position, firePoint.up);

        for (int i = 0; i < targetPoint.Length; i++)
        {
            RaycastHit2D hit = targetPoint[i];

            if (hit)
            {
                lineRenderer.sortingOrder = 3;
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, new Vector2(firePoint.position.x + (distance * -1), firePoint.position.y + levelFourAngle));

                if(hit.collider.gameObject.name.Contains("Box") || hit.collider.gameObject.name.Contains("Cube"))
                {
                    Destroy(hit.collider.gameObject);
                }
                if(hit.collider.gameObject.name.Equals("ButtonPressure (1)"))
                {
                    ButtonPressure.current.PressedByLaser();
                }
            }
            else
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, new Vector2(firePoint.position.x + (distance * -1), firePoint.position.y + levelFourAngle));
            }

            lineRenderer.enabled = true;

            yield return new WaitForSeconds(0.05f);

            lineRenderer.enabled = false;
        }

    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     StartCoroutine(LaserBeam());
    // }
}
