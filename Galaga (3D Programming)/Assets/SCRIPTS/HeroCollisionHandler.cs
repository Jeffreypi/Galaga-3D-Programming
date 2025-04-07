using UnityEngine;

public class HeroCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (GlobalScoreManager.Instance != null)
        {
            GlobalScoreManager.Instance.DecreaseHealth();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GlobalScoreManager.Instance != null)
        {
            GlobalScoreManager.Instance.DecreaseHealth();
        }
    }
}
