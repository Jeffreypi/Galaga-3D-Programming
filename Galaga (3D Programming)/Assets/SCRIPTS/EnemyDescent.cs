using UnityEngine;

public class EnemyRetreat : MonoBehaviour
{
    [SerializeField] private float waitTime = 3f;      // Time before retreating
    [SerializeField] private float retreatSpeed = 3f;  // Speed of retreat (negative Z direction)
    [SerializeField] private float rotationSpeed = 2f; // Speed of rotation

    private bool isRetreating = false;
    private bool isTurning = false;
    private float timer = 0f;

    void Update()
    {
        if (isRetreating)
        {
            transform.position += Vector3.back * retreatSpeed * Time.deltaTime; // Move along negative Z-axis
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= waitTime && !isTurning)
            {
                StartCoroutine(TurnAround());
            }
        }
    }

    private System.Collections.IEnumerator TurnAround()
    {
        isTurning = true;

        Quaternion targetRotation = Quaternion.Euler(0, 180, 0) * transform.rotation;

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        transform.rotation = targetRotation;
        isRetreating = true;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject); // Destroy when off-screen
    }
}
