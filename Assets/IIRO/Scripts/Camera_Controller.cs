using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform target; // The player's transform
    public float smoothSpeed = 0.125f; // Smoothness of camera movement
    public Vector3 offset; // Offset between camera and player

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Keep the camera's Z position constant
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}