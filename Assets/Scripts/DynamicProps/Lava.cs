using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject newWoodBox;
    private float damage = 1.75f;
    private bool boxColliding = false;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name.Contains("Player"))
        {
            HUD.current.damage = damage;
        }

        if (collision.collider.gameObject.name.Contains("IceCube"))
        {
            collision.collider.gameObject.transform.localScale -= new Vector3(0.001f, 0.006f, 0);
            collision.collider.gameObject.transform.Find("Steam").gameObject.SetActive(true);
            if (collision.collider.gameObject.transform.localScale.x <= 0.25)
            {
                Destroy(collision.collider.gameObject);
                collision.collider.gameObject.transform.Find("Steam").gameObject.SetActive(false);
            }
        }

        if (collision.collider.gameObject.name.Contains("WoodBox"))
        {
            boxColliding = true;
            GameObject woodBox = collision.collider.gameObject;
            StartCoroutine(DestroyWoodBox(woodBox));
        }
    }

    private IEnumerator DestroyWoodBox(GameObject woodBox)
    {
        if(boxColliding)
        {
            yield return new WaitForSeconds(2f);
            Destroy(woodBox);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        HUD.current.damage = 0;
    }

    private void FixedUpdate()
    {
        if(GameObject.Find("Boxes").gameObject.transform.childCount == 0)
        {
            GameObject box = Instantiate(newWoodBox, new Vector2(-24f, -20f), Quaternion.identity);
            box.transform.parent = GameObject.Find("Boxes").gameObject.transform;
        }
    }
}
