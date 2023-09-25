using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadingScreen1 : MonoBehaviour
{
    public TextMeshProUGUI softnessText; // Reference to the TextMeshPro text element
    public float softnessChangeDuration = 5.0f; // Duration for softness change
    public float targetSoftness = 1.0f; // Softness value to reach
    public string nextSceneName = "MainMenu"; // Name of the scene to load

    private float initialSoftness;
    private float timer;
    private bool transitioning = false;

    private void Start()
    {
        // Store the initial softness value
        initialSoftness = softnessText.fontMaterial.GetFloat("_Softness");

        // Start the softness change process
        timer = 0.0f;
        transitioning = false;
    }

    private void Update()
    {
        if (!transitioning)
        {
            // Update the timer
            timer += Time.deltaTime;

            // Calculate the softness value based on time
            float softness = Mathf.Lerp(initialSoftness, targetSoftness, timer / softnessChangeDuration);

            // Apply the softness value to the TextMeshPro text
            softnessText.fontMaterial.SetFloat("_Softness", softness);

            // Check if the softness change duration has been reached
            if (timer >= softnessChangeDuration)
            {
                // Ensure the final softness value is set
                softnessText.fontMaterial.SetFloat("_Softness", targetSoftness);

                // Trigger the scene transition
                transitioning = true;
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}