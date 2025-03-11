using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerMovementLogic : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float Speed;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

void PlayerMovementLogicUpdate(){
    if (Input.GetKey(KeyCode.LeftArrow)){
        this.transform.position += Vector3.left * this.Speed * Time.deltaTime;
    } else if(Input.GetKey(KeyCode.RightArrow)){
        this.transform.position += Vector3.right * this.Speed * Time.deltaTime;
    }
  //  PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f);
}
    // Update is called once per frame
    void Update()
    {
        PlayerMovementLogicUpdate();
    }
}
