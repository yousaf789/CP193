using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNotesRotation : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    public GameObject hud;
    public GameObject lighter;
    public GameObject img;
    public GameObject cam;
    public GameObject imgtext;
    public GameObject pickupImgText;
    public bool inReach;
    

    private FirstPersonMovement firstPersonMovementScript;
    private Jump jumpScript;
    private Crouch crouchScript;
    private FirstPersonLook firstPersonLookScript;
    private Zoom zoomScript;

    private bool isRotatingNote = false;
    private float rotationSpeed = 2.0f; // Adjust the speed of rotation as needed

    void Start()
    {
        noteUI.SetActive(false);
        hud.SetActive(true);
        lighter.SetActive(true);
        inReach = false;

        // Get references to the movement scripts
        firstPersonMovementScript = player.GetComponent<FirstPersonMovement>();
        jumpScript = player.GetComponent<Jump>();
        crouchScript = player.GetComponent<Crouch>();

        // Get refernce to camera scripts
        firstPersonLookScript = cam.GetComponent<FirstPersonLook>();
        zoomScript = cam.GetComponent<Zoom>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickupImgText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickupImgText.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact") && inReach)
        {
            // Disable the movement scripts
            // if (firstPersonMovementScript != null)
            // {
            firstPersonMovementScript.enabled = false;
            // }

            // if (jumpScript != null)
            // {
            jumpScript.enabled = false;
            // }

            // if (crouchScript != null)
            // {
            crouchScript.enabled = false;
            // }

            firstPersonLookScript.enabled = false;

            zoomScript.enabled = false;

            noteUI.SetActive(true);
            hud.SetActive(false);
            lighter.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            // Start the rotation when the note is open
            isRotatingNote = true;
        }

        if (isRotatingNote && Input.GetMouseButton(0))
        {
            // Rotate the note based on mouse input
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Adjust the rotation angles based on mouse input
            float rotationX = mouseY * rotationSpeed;
            float rotationY = mouseX * rotationSpeed;

            // Apply rotation to the note UI
            img.transform.Rotate(Vector3.up, rotationY, Space.World);
            img.transform.Rotate(Vector3.left, rotationX, Space.Self);
            imgtext.transform.Rotate(Vector3.up, rotationY, Space.World);
            imgtext.transform.Rotate(Vector3.left, rotationX, Space.Self);
        }
    }

    public void ExitButton()
    {
        // Enable the movement scripts
        // if (firstPersonMovementScript != null)
        // {
        firstPersonMovementScript.enabled = true;
        // }

        // if (jumpScript != null)
        // {
        jumpScript.enabled = true;
        // }

        // if (crouchScript != null)
        // {
        crouchScript.enabled = true;
        // }

        firstPersonLookScript.enabled = true;

        zoomScript.enabled = false;

        noteUI.SetActive(false);
        hud.SetActive(true);
        lighter.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Stop the rotation when exiting the note
        isRotatingNote = false;
    }
}
