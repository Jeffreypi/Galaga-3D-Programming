using UnityEngine;

public class EnemyDescent : MonoBehaviour
{
    [SerializeField] private float retreatSpeed = 3f;     
    [SerializeField] private float rotationSpeed = 2f;     
    [SerializeField] private float horizontalDriftMin = -0.5f; 
    [SerializeField] private float horizontalDriftMax = 0.5f;

    private bool isRetreating = false;
    private bool isTurning = false;

    private float waitTime;
    private float timer = 0f;
    private float xDriftSpeed = 0f;

    void Start()
    {
        waitTime = Random.Range(8f, 15f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!isTurning && timer >= waitTime)
        {
            StartCoroutine(TurnAround());
        }

        if (isRetreating)
        {
            Vector3 moveDir = new Vector3(xDriftSpeed, 0f, -retreatSpeed);
            transform.position += moveDir * Time.deltaTime;
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

        xDriftSpeed = Random.Range(horizontalDriftMin, horizontalDriftMax);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
