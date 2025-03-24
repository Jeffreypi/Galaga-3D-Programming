using System;
using UnityEngine;

public class FlyingEnemyBehaviour : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    public int currentWaypoint = 0;
    [SerializeField] public float _rotSpeed;

    void Start() { }

    public void SetWaypoints(Transform[] newWaypoints)
    {
        waypoints = newWaypoints;
    }

    private void RotateTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.forward = Vector3.RotateTowards(transform.forward, direction, _rotSpeed * Time.deltaTime, 0.0f);
    }

    private void MoveToWaypoint()
    {
        if (waypoints != null && currentWaypoint < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
            transform.LookAt(waypoints[currentWaypoint].position);

            if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
            {
                currentWaypoint++;
            }
        }
    }

    void Update()
    {
        if (currentWaypoint < waypoints.Length)
        {
            MoveToWaypoint();
        }
        else
        {
            Destroy(gameObject); // Enemy dies when reaching the last waypoint
        }
    }
}
