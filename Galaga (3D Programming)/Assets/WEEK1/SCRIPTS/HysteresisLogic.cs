using UnityEngine;

// moves this object to 'destination'
// according to P(t) += kh * ( D - C)
//  kh is hysteresis constant
//  D is destination
//  C is current
//
public class HysteresisLogic : MonoBehaviour
{
    [SerializeField] private Transform Destination;
    [SerializeField] private float kH;  // like a spring constant

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void HysteresisUpdate()
    {
        this.transform.position += kH * (Destination.position - this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        HysteresisUpdate();
    }
}
