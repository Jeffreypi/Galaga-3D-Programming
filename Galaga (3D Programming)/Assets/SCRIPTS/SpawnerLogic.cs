using System.Collections.Generic;
using UnityEngine;

public class SpawnerLogic : MonoBehaviour
{
    public static SpawnerLogic Instance {get; set;}
    [SerializeField] private GameObject _obj;
    [SerializeField] private KeyCode _key;
    public List<GameObject> numOfMissiles = new List<GameObject>();
    //var numberOfMissiles = GameObject.FindGameObjectWithTag("Missile").Length;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numOfMissiles.RemoveAll(item => item == null);
        if (numOfMissiles.Count < 2){
        if (Input.GetKeyDown(_key) == true)
        {
           GameObject newMissile = Instantiate(_obj, this.transform.position, this.transform.rotation);
            numOfMissiles.Add(newMissile);
        }
        
        }
    }
}
