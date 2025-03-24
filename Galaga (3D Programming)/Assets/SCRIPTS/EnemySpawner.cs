using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;  // Enemy to spawn
    [SerializeField] private Transform spawnPoint;    // Spawn location
    [SerializeField] private float spawnDelay = 3f;   // Delay before spawning

    private void Start()
    {
        Invoke(nameof(SpawnEnemy), spawnDelay);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
