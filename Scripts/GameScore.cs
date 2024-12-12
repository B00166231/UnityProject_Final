using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour
{
    public int score = 0;  // Holds the score
    public static GameScore inst;  // Singleton instance
    public TextMeshProUGUI scoreText;  // Reference to the UI text that shows the score
    public PlayerMovement playerMovement;  // Reference to PlayerMovement instance

    private void Awake()
    {
        // Ensure that the instance is set to this script
        if (inst == null)
        {
            inst = this;
        }
        else if (inst != this)
        {
            Destroy(gameObject);  // Destroy duplicate instances
        }
    }

    // Method to increment the score
    public void IncrementScore()
    {
        score++;  // Increase the score by 1
        UpdateScoreText();  // Update the UI text to show the new score
    }

    // Method to update the score text in the UI
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            // Update the score text
            scoreText.text = "SCORE: " + score;
            // Increase Player Speed
            playerMovement.speed += playerMovement.speedIncreasePerScore;
        }
    }

    void Start()
    {
        // Optionally, initialize the score text if required
        UpdateScoreText();  // Initialize the score text at the start
    }
}
