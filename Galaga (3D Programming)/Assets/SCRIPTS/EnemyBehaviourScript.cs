using System;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyBehaviourScript : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    public int currentWaypoint = 0;
    [SerializeField] private float kH;  // like a spring constant
    [SerializeField] private float _rotSpeed;
    public event Action onAddedToGrid;
    private RBYBeeGrid grid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }
    public void SetWayPoints(Transform[] newWaypoints){
        waypoints = newWaypoints;
    }
    public void SetGrid(RBYBeeGrid gridReference){
        grid = gridReference;
    }
    void RotateTowards(Vector3 targetPosition){
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.forward = Vector3.RotateTowards(transform.forward, direction, _rotSpeed * Time.deltaTime, 0.0f);

    }
    public void MoveToWaypoint(){
        if (waypoints != null && currentWaypoint < waypoints.Length){
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, 
            speed*Time.deltaTime);
           // RotateTowards(waypoints[currentWaypoint].position);
            transform.LookAt(waypoints[currentWaypoint].position);

            if(Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f){
                currentWaypoint++;
            }}}

    
    public void AddToGrid(){
        if(grid != null){
            grid.AddToGrid(gameObject);
            //onAddedToGrid?.Invoke();
            enabled = false;
        }
    }
    
    void Update()
    {
        
        if (currentWaypoint < waypoints.Length){
            MoveToWaypoint();
        }
        else 
        {
            AddToGrid();
        }
      
        
    }
        
}
