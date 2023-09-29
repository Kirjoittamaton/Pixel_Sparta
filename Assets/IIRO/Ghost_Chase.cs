using UnityEngine;

public class GhostChase : MonoBehaviour
{
    public float moveSpeed = 3.0f; // Speed at which the ghost moves
    private Transform player; // Reference to the player's transform
    private Rigidbody2D rb; // Reference to the ghost's Rigidbody2D

    private void Start()
    {
        // Find the player GameObject by tag and get its transform
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the ghost to the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Apply a force to the ghost in the direction of the player
            rb.AddForce(direction * moveSpeed);
        }
    }
}