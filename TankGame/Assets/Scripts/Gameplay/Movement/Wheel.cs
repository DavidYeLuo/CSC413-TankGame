using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] private WheelCollider collider;

    [Header("Debug")] 
    // Cache
    [SerializeField] private float rpm;

    [SerializeField] private float steerAngle;
    [SerializeField] private Quaternion rot;
    [SerializeField] private Vector3 temp;

    // Update is called once per frame
    void FixedUpdate()
    {
        rpm = collider.rpm;
        steerAngle = collider.steerAngle;
        
        // deltaTime is in seconds so we convert angular velocity from minutes to seconds.
        // transform.Rotate(rpm / 60 * Time.deltaTime * Vector3.right);
        
        // Gets Transform and rotation from the global coordinate
        // We just need the rotation
        
        collider.GetWorldPose(out temp ,out rot);
        transform.rotation = rot;
        transform.position = temp;
        // transform.position = temp;
        // transform.Rotate(steerAngle * Vector3.up);
    }
}
