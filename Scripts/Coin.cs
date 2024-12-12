using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f;  // Speed at which the coin rotates

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the coin is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Increment the score via the GameScore singleton
            GameScore.inst.IncrementScore();

            // Destroy the coin object after it's collected
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Optional start logic if needed
    }

    private void Update()
    {
        // Make the coin rotate continuously
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
