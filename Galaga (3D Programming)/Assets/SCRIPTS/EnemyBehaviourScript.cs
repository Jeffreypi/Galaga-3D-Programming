using System;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    public int currentWaypoint = 0;
    [SerializeField] private float kH;  // like a spring constant
    [SerializeField] private float _rotSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }
    void RotateTowards(Vector3 targetPosition){
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.forward = Vector3.RotateTowards(transform.forward, direction, _rotSpeed * Time.deltaTime, 0.0f);

    }
    
    void Update()
    {
        if (currentWaypoint < waypoints.Length){
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, 
            speed*Time.deltaTime);
           // RotateTowards(waypoints[currentWaypoint].position);
            transform.LookAt(waypoints[currentWaypoint].position);

            if(Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f){
                currentWaypoint++;
            }
        }
        else{
            GetComponent<RBYBeeGrid>().enabled = true;
            enabled = false;
        }
      
        
    }
}
