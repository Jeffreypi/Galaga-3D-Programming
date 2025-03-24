using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;              // Forward movement speed
    public float waveFrequency = 2f;     // How fast the enemy oscillates left-right
    public float waveAmplitude = 4f;     // Max distance left-right from center
    public float spinSpeed = 100f;       // Rotation speed

    private float startX;                // Initial X position (to stay centered)
    private float startZ;                // Initial Z position

    void Start()
    {
        startX = transform.position.x;  // Store the starting X position
        startZ = transform.position.z;  // Store the starting Z position
    }

    void Update()
    {
        // Move forward over time
        float zMovement = speed * Time.deltaTime;

        // Oscillate left and right relative to startX
        float xMovement = Mathf.Sin(Time.time * waveFrequency) * waveAmplitude;

        // Apply movement (keep centered by adding xMovement to startX)
        transform.position = new Vector3(startX + xMovement, transform.position.y, transform.position.z - zMovement);

        // Rotate the enemy while moving
        SpinEnemy();

        // Destroy the enemy when it moves off-screen
        if (transform.position.z < -10f)
        {
            Destroy(gameObject);
        }
    }

    private void SpinEnemy()
    {
        // Rotate the enemy around its Y-axis
        transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
    }
}
