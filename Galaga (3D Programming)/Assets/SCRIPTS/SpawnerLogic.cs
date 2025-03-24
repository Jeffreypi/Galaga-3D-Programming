// using System.Collections.Generic;
// using UnityEngine;

// public class SpawnerLogic : MonoBehaviour
// {
//     public static SpawnerLogic Instance {get; set;}
//     [SerializeField] private GameObject _obj;
//     [SerializeField] private KeyCode _key;
//     public List<GameObject> numOfMissiles = new List<GameObject>();
//     //var numberOfMissiles = GameObject.FindGameObjectWithTag("Missile").Length;
    
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         numOfMissiles.RemoveAll(item => item == null);
//         if (numOfMissiles.Count < 2){
//         if (Input.GetKeyDown(_key) == true)
//         {
//            GameObject newMissile = Instantiate(_obj, this.transform.position, this.transform.rotation);
//             numOfMissiles.Add(newMissile);
//         }
        
//         }
//     }
// }
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLogic : MonoBehaviour
{
    public static SpawnerLogic Instance { get; private set; }

    [SerializeField] private GameObject _missilePrefab;
    [SerializeField] private KeyCode _fireKey = KeyCode.Space;

    [SerializeField] private int maxMissiles = -1; // -1 means unlimited
    public List<GameObject> activeMissiles = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        // Clean up destroyed missiles
        activeMissiles.RemoveAll(missile => missile == null);

        bool canFire = maxMissiles < 0 || activeMissiles.Count < maxMissiles;

        if (canFire && Input.GetKeyDown(_fireKey))
        {
            SpawnMissile();
        }
    }

    private void SpawnMissile()
    {
        GameObject newMissile = Instantiate(
            _missilePrefab,
            transform.position,
            transform.rotation
        );
        activeMissiles.Add(newMissile);
    }
}
