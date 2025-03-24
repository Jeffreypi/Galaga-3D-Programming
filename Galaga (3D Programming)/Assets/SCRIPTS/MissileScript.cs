using UnityEngine;

public class MissileScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float Speed;
    [SerializeField] private int scoreValue = 1; // Points awarded per hit

    void Start()
    {
        transform.rotation = Quaternion.identity;
        FindObjectOfType<PlayerMovementLogic>()?.PlayMissileSound(true); // Play missile launch sound
    }

    void Update()
    {
        transform.position += Vector3.forward * Speed * Time.deltaTime;
    }

    // Destroy the missile when it leaves the camera view
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            GlobalScoreManager.Instance?.AddScore(scoreValue); // Increment score
            Destroy(other.gameObject);
        }
        FindObjectOfType<PlayerMovementLogic>()?.PlayMissileSound(false); // Play missile impact sound
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            GlobalScoreManager.Instance?.AddScore(scoreValue); // Increment score
            Destroy(collision.gameObject);
        }
        FindObjectOfType<PlayerMovementLogic>()?.PlayMissileSound(false); // Play missile impact sound
        Destroy(gameObject);
    }
}
