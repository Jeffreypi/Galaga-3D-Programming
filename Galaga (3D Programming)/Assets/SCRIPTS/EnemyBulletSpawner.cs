using UnityEngine;
using System.Collections.Generic;

public class EnemyBulletSpawner : MonoBehaviour
{
    public static EnemyBulletSpawner Instance { get; set; }
    
    [SerializeField] private GameObject _obj;          // Bullet prefab
    [SerializeField] private Transform player;         // Reference to the player
    [SerializeField] private float minSpawnTime = 0.5f; // Minimum time between spawns
    [SerializeField] private float maxSpawnTime = 2f;   // Maximum time between spawns
    [SerializeField] private int maxMissiles = 10;      // Max number of bullets allowed
    [SerializeField] private float bulletSpeed = 10f;   // Speed of the bullets

    private float nextSpawnTime;
    public List<GameObject> numOfMissiles = new List<GameObject>();

    void Start()
    {
        SetNextSpawnTime(); // Set initial random spawn time
    }

    void Update()
    {
        // Remove destroyed bullets from the list
        numOfMissiles.RemoveAll(item => item == null);

        // Check if we can spawn more bullets
        if (numOfMissiles.Count < maxMissiles && Time.time >= nextSpawnTime)
        {
            SpawnMissile();
            SetNextSpawnTime(); // Set the next random spawn time
        }
    }

    private void SpawnMissile()
    {
        // Instantiate the bullet at the current position and rotation
        GameObject newMissile = Instantiate(_obj, this.transform.position, Quaternion.identity);

        // Check if the player exists before proceeding
        if (player != null)
        {
            // Calculate direction to player
            Vector3 directionToPlayer = (player.position - newMissile.transform.position).normalized;

            // Check if bullet has a Rigidbody
            Rigidbody rb = newMissile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Move the bullet toward the player
                rb.linearVelocity = directionToPlayer * bulletSpeed;
            }
        }

        // Add the missile to the list
        numOfMissiles.Add(newMissile);
    }

    private void SetNextSpawnTime()
    {
        // Set a random time interval for the next spawn
        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }
}
