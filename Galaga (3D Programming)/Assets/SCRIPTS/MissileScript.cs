using UnityEngine;

public class MissileScript : MonoBehaviour
{   [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float Speed;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
//you need to hide the scenview in unity for this to work properly.
//If yhe sceneview can see it, the object wont be destroyed
    void OnBecameInvisible()
    {
        Destroy(gameObject);
       
        
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.forward * this.Speed * Time.deltaTime;
    }
}
