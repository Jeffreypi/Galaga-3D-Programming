using UnityEngine;

public class EnemySpawnLogic : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Transform[] waypoints;
    public float spawnInterval = 1f;
    private int maxEnemies;
    private int currentEnemies = 0;
    private float spawnTimer;
    private RBYBeeGrid grid;
    private EnemyBehaviourScript enemyBehaviourScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grid = FindAnyObjectByType<RBYBeeGrid>();
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnInterval){
            SpawnEnemy();
            spawnTimer = 0;
        }

        
    }

    void SpawnEnemy(){
        if (currentEnemies < grid.columnLength * grid.rowLength){
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        EnemyBehaviourScript enemyScript = enemy.GetComponent<EnemyBehaviourScript>();
        enemyScript.SetWayPoints(waypoints);
        enemyScript.SetGrid(grid);
       // enemyScript.onAddedToGrid += HandleEnemyAddedToGrid;
        currentEnemies++;
    }}
    // void HandleEnemyAddedToGrid(){
    //     currentEnemies--;
    // }
}
