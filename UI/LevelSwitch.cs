using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    [SerializeField] private int levelIdx;
    [SerializeField] private GameObject bossEnemy; // Reference to the boss enemy

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        //     if (bossEnemy == null || !bossEnemy.activeInHierarchy)
        //     {
                if (levelIdx <= 2)
                    SceneManager.LoadScene(levelIdx + 1);
                else
                    Application.Quit();
    //         }
    //         else
    //         {
    //             Debug.Log("The boss is still alive! Defeat the boss to proceed.");
    //         }
        }
    }
}
