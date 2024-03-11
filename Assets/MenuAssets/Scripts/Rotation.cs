using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    /*
     * Continuously rotate an object around any axis. 
     * Alter rotation speed to start the object's rotation, with 0 being no rotation in that given axis.
     * 
     */
    [SerializeField] private float X_Axis_Rotation = 0;
    [SerializeField] private float Y_Axis_Rotation = 0;
    [SerializeField] private float Z_Axis_Rotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(X_Axis_Rotation*Time.deltaTime, Y_Axis_Rotation*Time.deltaTime, Z_Axis_Rotation * Time.deltaTime);
    }
}
