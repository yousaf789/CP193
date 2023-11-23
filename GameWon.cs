using UnityEngine;

public class GameWon : MonoBehaviour
{
    public GameObject gameWonScreenUI;
    public GameObject player;
    public GameObject mainCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetGameWonState();
        }
    }

    private void SetGameWonState()
    {
        // Enable the game won screen UI
        if (gameWonScreenUI != null)
        {
            gameWonScreenUI.SetActive(true);
        }

        // Disable the player
        if (player != null)
        {
            player.SetActive(false);
        }

        // Show and unlock the cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Enable or activate any additional elements like cameras
        if (mainCamera != null)
        {
            mainCamera.SetActive(true);
        }
    }
}
