using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladder : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().name.Equals("LevelOne"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelTwo");
        }
        if (SceneManager.GetActiveScene().name.Equals("LevelTwo"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
            // UnityEngine.SceneManagement.SceneManager.LoadScene("LevelThree");
        }
    }
}
