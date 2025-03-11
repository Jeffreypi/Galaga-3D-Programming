using UnityEngine;

public class MissileScript : MonoBehaviour
{   [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float Speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.forward * this.Speed * Time.deltaTime;
    }
}
