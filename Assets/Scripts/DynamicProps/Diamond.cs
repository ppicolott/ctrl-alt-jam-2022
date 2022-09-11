using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diamond : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ManagerStates.diamond += 1;
            Destroy(this.gameObject);
        }
    }
}
