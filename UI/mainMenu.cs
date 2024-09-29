using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This function will be called when the Start button is pressed
    public void StartGame()
    {
        // Load the next scene (you can replace the index with the correct one)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // This function will be called when the Quit button is pressed
    public void QuitGame()
    {
        Debug.Log("Quit!");  // This will print in the console while testing in the editor
        Application.Quit();  // This will close the game when running a build
    }
}
