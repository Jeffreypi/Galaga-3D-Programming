using UnityEngine;

public class PlayerMovementLogic : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float Speed;
    [SerializeField] private AudioSource audioSource; // Audio source for sound playback
    [SerializeField] private AudioClip missileLaunchSound; // Sound for missile launch
    [SerializeField] private AudioClip missileImpactSound; // Sound for missile impact

    void Update()
    {
        PlayerMovementLogicUpdate();
    }

    void PlayerMovementLogicUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Speed * Time.deltaTime;
        }
    }

    public void PlayMissileSound(bool isLaunch)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(isLaunch ? missileLaunchSound : missileImpactSound);
        }
    }
}
