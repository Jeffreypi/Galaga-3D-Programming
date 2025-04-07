using UnityEngine;

public class PlayerMovementLogic : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float Speed;

    // Serialized AudioSource for playing sound
    [SerializeField] private AudioSource missileAudioSource;
    [SerializeField] private AudioClip missileLaunchSound;
    [SerializeField] private AudioClip missileImpactSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // You can perform any initialization here if necessary
    }

    // Method to play missile sound
    public void PlayMissileSound(bool isLaunch)
    {
        if (missileAudioSource != null)
        {
            if (isLaunch && missileLaunchSound != null)
            {
                missileAudioSource.PlayOneShot(missileLaunchSound); // Play launch sound
            }
            else if (!isLaunch && missileImpactSound != null)
            {
                missileAudioSource.PlayOneShot(missileImpactSound); // Play impact sound
            }

            Debug.Log("Missile sound played");
        }
    }

    // Player movement logic update method
    void PlayerMovementLogicUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.Speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.Speed * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementLogicUpdate();
    }
}
