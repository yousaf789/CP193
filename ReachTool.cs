using UnityEngine;

public class ReachTool : MonoBehaviour
{
    public Transform cameraTransform; // Reference to the camera transform

    // Offset relative to the camera
    public Vector3 relativePosition = new Vector3(0f, 0f, 1.28f);

    void Update()
    {
        // Ensure the reach tool follows the camera's position and rotation
        transform.position = cameraTransform.position + cameraTransform.TransformDirection(relativePosition);
        transform.rotation = cameraTransform.rotation;

        // Your other logic for the reach tool
    }
}
