using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RBYBeeGrid : MonoBehaviour
{
    public int columnLength;
    public int rowLength;
    public float x_space;
    public float z_space;

    [SerializeField] private float moveDelay = 2.0f; // Time between grid movements
    [SerializeField] private float moveSpeed = 2.0f; // Speed of movement between targets

    [SerializeField] private List<Transform> movementPoints; // Possible movement locations
    [SerializeField] private Transform currentMovementPoint; // Displays the current movement point

    [SerializeField] private int objectCount = 0; // Serialized field tracking objects in grid

    private List<int> availableIndexes; // Tracks available grid positions
    private Dictionary<GameObject, int> enemyPositions; // Maps enemies to grid positions

    private void Start()
    {
        InitializeGridPositions();
        enemyPositions = new Dictionary<GameObject, int>();
        StartCoroutine(MoveGridSmoothly());
    }

    private void InitializeGridPositions()
    {
        availableIndexes = new List<int>();

        for (int i = 0; i < columnLength * rowLength; i++)
        {
            availableIndexes.Add(i); // Fill list with all possible positions
        }
    }

    public bool HasRoomInGrid()
    {
        return availableIndexes.Count > 0; // Check if there are free slots
    }

    private Vector3 GetGridPosition(int index)
    {
        int row = index / columnLength;
        int column = index % columnLength;

        return transform.position + new Vector3(x_space * column, 0, -z_space * row);
    }

    public void AddToGrid(GameObject enemy)
    {
        if (HasRoomInGrid())
        {
            int randomIndex = Random.Range(0, availableIndexes.Count); // Pick a random free index
            int gridIndex = availableIndexes[randomIndex];
            availableIndexes.RemoveAt(randomIndex); // Remove from available spots

            Vector3 targetPosition = GetGridPosition(gridIndex);
            enemy.transform.position = targetPosition;
            enemy.transform.rotation = Quaternion.identity;
            enemy.transform.SetParent(transform); // Attach to grid so it moves with it

            enemyPositions[enemy] = gridIndex; // Store the grid position for tracking
            objectCount++; // Increment object count
        }
        else
        {
            Debug.LogWarning("Grid is full");
        }
    }

    public void RemoveFromGrid(GameObject enemy)
    {
        if (enemyPositions.ContainsKey(enemy))
        {
            int gridIndex = enemyPositions[enemy]; // Get the grid index
            availableIndexes.Add(gridIndex); // Return it to the available pool
            enemyPositions.Remove(enemy); // Remove from the tracking dictionary
            objectCount--; // Decrement object count
            Destroy(enemy); // Destroy the enemy object
        }
    }

    private IEnumerator MoveGridSmoothly()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);

            if (movementPoints.Count == 0) yield break;

            Transform targetPoint = movementPoints[Random.Range(0, movementPoints.Count)];
            currentMovementPoint = targetPoint;
            Vector3 targetPosition = targetPoint.position;

            float epsilon = 0.01f;
            while (Vector3.Distance(transform.position, targetPosition) > epsilon)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            transform.position = targetPosition;
        }
    }
}
