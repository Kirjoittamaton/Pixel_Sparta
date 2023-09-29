using UnityEngine;
using UnityEngine.SceneManagement;

public class SCENE20 : MonoBehaviour
{
    public float delayInSeconds = 20f; // The delay in seconds before changing scenes
    public string sceneToLoad = "Level3"; // The name of the scene to load (make sure it's in the build settings)

    private float timer = 0f;
    private bool hasSceneLoaded = false;

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if the delay has been reached and the scene hasn't been loaded yet
        if (timer >= delayInSeconds && !hasSceneLoaded)
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
            hasSceneLoaded = true; // Set a flag to ensure the scene is loaded only once
        }
    }
}