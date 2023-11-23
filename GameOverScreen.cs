using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public GameObject GameOverScreenUI;
    public GameObject player;
    public GameObject enemy;
    public GameObject cam;

    void Start()
    {
        GameOverScreenUI.SetActive(false);
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameOverScreenUI.SetActive(true);
            player.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            cam.SetActive(true);
        }
    }
}
