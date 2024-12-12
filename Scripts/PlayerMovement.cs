using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private bool alive = true;  // Track if the player is alive

    public float speed = 5;
    public Rigidbody rb;

    private float horizontalInput;
    public float horizontalMultiplier = 2;

    public float speedIncreasePerScore = 0.1f;

    private void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!alive) return;

        // Player movement logic (forward and horizontal movement)
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        // Handle horizontal input for player movement
        horizontalInput = Input.GetAxis("Horizontal");

        // If the player falls below a certain Y position, they die
        if (transform.position.y < -5)
        {
            Dead();
        }
    }

    public void Dead()
    {
        if (!alive) return;

        alive = false;
        Debug.Log("Player Dead. Restarting scene...");

        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
