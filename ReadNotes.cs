using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNotes : MonoBehaviour
{
    public GameObject player;
    public GameObject noteUI;
    public GameObject hud;
    public GameObject lighter;
    public GameObject cam;
    public bool inReach;
    public GameObject readNoteText;

    private FirstPersonMovement firstPersonMovementScript;
    private Jump jumpScript;
    private Crouch crouchScript;
    private FirstPersonLook firstPersonLookScript;
    private Zoom zoomScript;

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
            readNoteText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            readNoteText.SetActive(false);
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

            // firstPersonLookScript.enabled = false;

            zoomScript.enabled = false;

            noteUI.SetActive(true);
            hud.SetActive(false);
            lighter.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

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

        // firstPersonLookScript.enabled = true;

        zoomScript.enabled = false;

        noteUI.SetActive(false);
        hud.SetActive(true);
        lighter.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
}
