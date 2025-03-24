using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlyingEnemySpawnLogic : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<Transform> waypoints; // Waypoints for movement
    [SerializeField] private float spawnInterval = 2.0f;
    [SerializeField] private float enemySpeed = 3.0f;
    [SerializeField] private float rotationSpeed = 5.0f;
    [SerializeField] private int enemySpawnAmount = 10; // Max number of enemies to spawn

    private int enemiesSpawned = 0; // Track how many enemies have spawned

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (enemiesSpawned < enemySpawnAmount) // Stop when max is reached
        {
            SpawnEnemy();
            enemiesSpawned++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        if (waypoints.Count == 0) return;

        GameObject enemy = Instantiate(enemyPrefab, waypoints[0].position, Quaternion.identity);
        FlyingEnemyBehaviour enemyScript = enemy.GetComponent<FlyingEnemyBehaviour>();

        if (enemyScript != null)
        {
            enemyScript.SetWaypoints(waypoints.ToArray()); // Pass waypoints
            enemyScript.speed = enemySpeed; // Set speed
            enemyScript._rotSpeed = rotationSpeed; // Set rotation speed
        }
    }
}
