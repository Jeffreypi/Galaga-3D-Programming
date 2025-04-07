using UnityEngine;

public class MissileScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;  // Rigidbody of the missile
    [SerializeField] private float Speed;          // Speed of the missile
    [SerializeField] private int scoreValue = 10;  // Score value when the missile hits an object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.rotation = Quaternion.identity;

        // Find the PlayerMovementLogic component
        PlayerMovementLogic playerMovementLogic = FindObjectOfType<PlayerMovementLogic>();
        if (playerMovementLogic != null)
        {
            playerMovementLogic.PlayMissileSound(true); // Play missile launch sound
        }
    }

    // If the missile goes off-screen, destroy it
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Move missile forward at the specified speed
        transform.position += Vector3.forward * Speed * Time.deltaTime;
    }

    // On collision with any object, check if it's tagged "Respawn"
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            // Increment the score and destroy the object that was hit
            GlobalScoreManager.Instance?.AddScore(scoreValue);
            Destroy(collision.gameObject); // Destroy the object hit
        }

        // Find the PlayerMovementLogic component again to play impact sound
        PlayerMovementLogic playerMovementLogic = FindObjectOfType<PlayerMovementLogic>();
        if (playerMovementLogic != null)
        {
            playerMovementLogic.PlayMissileSound(false); // Play missile impact sound
        }

        // Destroy the missile after impact
        Destroy(gameObject);
    }
}
