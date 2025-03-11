using UnityEngine;

public class SpawnerLogic : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private KeyCode _key;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_key) == true)
        {
            Instantiate(_obj, this.transform.position, this.transform.rotation);
        }
    }
}
