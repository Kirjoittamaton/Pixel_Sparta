using UnityEngine;

public class DisableOnCollision : MonoBehaviour
{
    // Specify the tag of the object you want to detect collisions with.
    public string targetTag = "Player";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the specified tag.
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Disable the GameObject when a collision with the target object occurs.
            gameObject.SetActive(false);
        }
    }
}