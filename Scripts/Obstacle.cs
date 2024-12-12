using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    private PlayerMovement playerMovement;  // Reference to PlayerMovement, if needed for resetting or scoring logic

    private void Start()
    {
        // Ensure we get the PlayerMovement instance from the scene
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the Player object
        if (collision.gameObject.CompareTag("Player"))
        {
            // Call ResetPlayer to reload the scene on collision with an obstacle
            ResetPlayer();
        }
    }

    private void ResetPlayer()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        // Update logic if needed, currently empty as no functionality is required for this script
    }
}
