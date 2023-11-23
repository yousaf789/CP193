using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public GameObject cam;
    // This function will be called when the reset button is clicked
    public void ResetGame()
    {
        // Load the current scene to reset the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        cam.SetActive(false);
    }
}
