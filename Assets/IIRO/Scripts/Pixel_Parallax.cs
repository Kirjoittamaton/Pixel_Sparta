using UnityEngine;

public class Pixel_Parallax : MonoBehaviour
{
    public Transform[] backgrounds;  // Array of background layers to parallax
    public float[] parallaxScales;   // The proportion of movement to move the backgrounds by
    public float smoothing = 1f;     // How smooth the parallax effect is (0 for no smoothing)

    private Transform cam;           // Reference to the main camera's transform
    private Vector3 previousCamPos;  // The position of the camera in the previous frame

    void Awake()
    {
        // Reference to the main camera
        cam = Camera.main.transform;
    }

    void Start()
    {
        // Store the initial positions of the backgrounds and the camera
        previousCamPos = cam.position;

        // Ensure the length of parallaxScales matches the length of backgrounds
        if (backgrounds.Length != parallaxScales.Length)
        {
            Debug.LogError("Backgrounds and Parallax Scales arrays must have the same length.");
        }
    }

    void Update()
    {
        // For each background layer
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Calculate the parallax position
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            // Calculate the target x position
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // Create a target position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Smoothly interpolate between the current position and the target position
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // Update the previous camera position
        previousCamPos = cam.position;
    }
}