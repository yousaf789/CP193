using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool isCrouching;

    // float defaultHeight = 3.8f;
    // float crouchHeight = 1.0f;
    float defaultHeight;
    float crouchHeight;

    Vector3 originalCenter;
    Vector3 crouchingCenter;

    void Start()
    {
        controller = GetComponent<CharacterController>();   
        defaultHeight = controller.height;
        crouchHeight = defaultHeight * 0.5f;

        originalCenter = controller.center;
        crouchingCenter = new Vector3(0f, crouchHeight / 2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player wants to crouch
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Toggle between crouching and standing
            if (isCrouching)
            {
                // Return to standing height
                controller.height = defaultHeight;
                isCrouching = false;
            }
            else
            {
                // Crouch the player
                controller.height = crouchHeight;
                isCrouching = true;
            }
        }

        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Get player input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 move = transform.right * x + transform.forward * z;

        // Apply movement to player
        controller.Move(move * speed * Time.deltaTime);

        // Apply gravity to player
        velocity.y += gravity * Time.deltaTime;
        
        controller.Move(velocity * Time.deltaTime);
    }
}
