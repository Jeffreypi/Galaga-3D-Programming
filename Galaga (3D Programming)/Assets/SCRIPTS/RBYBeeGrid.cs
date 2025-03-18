using Unity.Mathematics;
using UnityEngine;

public class RBYBeeGrid : MonoBehaviour
{
    public int columnLength;
    public int rowLength;
    public float x_space;
    public float z_space;
    [SerializeField] private float x_Start;
    [SerializeField] private float y_Start;
    //public GameObject RBYBee;
    private int nextGridIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    //     for(int i=0; i < columnLength * rowLength; i++){
    //     Instantiate(RBYBee, GetGridPosition(i), Quaternion.identity);
    //     //Instantiate(RBYBee, new Vector3(x_space*(i %columnLength), 0, z_space * (i / columnLength)), Quaternion.identity);
    // }
        
    }
    private Vector3 GetGridPosition(int index){
        int row = index / columnLength;
        int column = index % columnLength;
        return new Vector3(x_Start+(x_space * column), 0,  y_Start+(-z_space * row));
    }

    public void AddToGrid(GameObject enemy){
        if(nextGridIndex < columnLength * rowLength){
            Vector3 targetPostion = GetGridPosition(nextGridIndex);;
            enemy.transform.position = targetPostion;
            enemy.transform.rotation = Quaternion.identity;
            nextGridIndex++;
        }
        else{
            Debug.LogWarning("Grid is full");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
