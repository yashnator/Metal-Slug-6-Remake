using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    public void Awake() {
        gameOverScreen.SetActive(false);
    }

    public void GameOver() {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

    public void Quit() {
        Application.Quit();
        // UnityEditor.EditorApplication.isPlaying = false;
    }

    public void StartGame()
    {
        // Load the next scene (you can replace the index with the correct one)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
