using UnityEngine;
using UnityEngine.SceneManagement;

public class ToEnd : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene you want to load

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an object tagged as "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}