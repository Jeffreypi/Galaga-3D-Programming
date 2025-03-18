using UnityEngine;

public class RBYBeeGrid : MonoBehaviour
{
    public int columnLength;
    public int rowLength;
    public float x_space;
    public float z_space;
    public GameObject RBYBee;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {for(int i=0; i < columnLength * rowLength; i++){
        Instantiate(RBYBee, new Vector3(x_space*(i %columnLength), 0, z_space * (i / columnLength)), Quaternion.identity);
    }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
