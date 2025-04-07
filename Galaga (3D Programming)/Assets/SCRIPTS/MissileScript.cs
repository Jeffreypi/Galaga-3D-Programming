using UnityEngine;

public class MissileScript : MonoBehaviour
{   [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float Speed;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
<<<<<<< Updated upstream
        
=======
        transform.rotation = Quaternion.identity;
        PlayerMovementLogic playerMovementLogic = Object.FindFirstObjectByType<PlayerMovementLogic>();
        if (playerMovementLogic != null)
        {
            playerMovementLogic.PlayMissileSound(true); // Play missile launch sound
        }
>>>>>>> Stashed changes
    }
//you need to hide the scenview in unity for this to work properly.
//If yhe sceneview can see it, the object wont be destroyed
    void OnBecameInvisible()
    {
        Destroy(gameObject);
       
        
    }
    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        this.transform.position += Vector3.forward * this.Speed * Time.deltaTime;
=======
        if (other.CompareTag("Respawn"))
        {
            GlobalScoreManager.Instance?.AddScore(scoreValue); // Increment score
            Destroy(other.gameObject);
        }
        PlayerMovementLogic playerMovementLogic = Object.FindFirstObjectByType<PlayerMovementLogic>();
        if (playerMovementLogic != null)
        {
            playerMovementLogic.PlayMissileSound(false); // Play missile impact sound
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            GlobalScoreManager.Instance?.AddScore(scoreValue); // Increment score
            Destroy(collision.gameObject);
        }
        PlayerMovementLogic playerMovementLogic = Object.FindFirstObjectByType<PlayerMovementLogic>();
        if (playerMovementLogic != null)
        {
            playerMovementLogic.PlayMissileSound(false); // Play missile impact sound
        }
        Destroy(gameObject);
>>>>>>> Stashed changes
    }
}
