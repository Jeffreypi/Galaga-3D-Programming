using UnityEngine;

public class EnemySpawnLogic : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float waitTime = 9f; // Time before spawning starts
    [SerializeField] private int maxEnemies = 10; // Spawn limit

    private int currentEnemies = 0;
    private float spawnTimer;
    private float waitTimer;
    private bool canSpawn = false;
    private RBYBeeGrid grid;

    void Start()
    {
        grid = FindAnyObjectByType<RBYBeeGrid>();
        waitTimer = 0f;
    }

    void Update()
    {
        // Wait before allowing spawning
        if (!canSpawn)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                canSpawn = true;
                spawnTimer = 0f; // Reset spawn timer when wait time ends
            }
            return;
        }

        // Normal spawning logic after wait time
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (currentEnemies < maxEnemies)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            EnemyBehaviourScript enemyScript = enemy.GetComponent<EnemyBehaviourScript>();
            enemyScript.SetWayPoints(waypoints);
            enemyScript.SetGrid(grid);
            currentEnemies++;
        }
    }
}
