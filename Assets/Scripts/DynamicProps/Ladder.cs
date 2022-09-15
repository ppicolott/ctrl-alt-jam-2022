using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladder : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (GameplayController.level)
        {
            case 1:
                SceneManager.LoadScene("LevelTwo");
                break;
            case 2:
                SceneManager.LoadScene("LevelThree");
                break;
            case 3:
                SceneManager.LoadScene("LevelFour");
                break;
            case 4:
                SceneManager.LoadScene("LevelFive");
                break;
            case 5:
                SceneManager.LoadScene("Victory");
                //SceneManager.LoadScene("LevelSix");
                break;
            case 6:
                SceneManager.LoadScene("Victory");
                break;
        }
    }
}
