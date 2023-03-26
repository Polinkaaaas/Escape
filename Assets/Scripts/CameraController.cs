using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool useOffsetValues;
    public float rotateSpeed;
    void Start()
    {
        if (!useOffsetValues)
        {
            offset = target.position - transform.position;
        }
    }
    void Update()
    {
        //get the x position of the mouse and rotate the target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);
        
        //move the amera based on the current rotation of the target and the original offset
        float desiredYAngle = target.eulerAngles.y;

        Quaternion rotation = Quaternion.Euler(0, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);
        
       // transform.position = target.position - offset;
   
        transform.LookAt(target);
    }
}
