using UnityEngine;

namespace Gameplay.Mesh
{
    /**
 * This class is used to match the mesh's rotation to the collider rotation.
 * Normally the collider rotation doesn't rotate the mesh so we have to do it manually.
 * This is similar to MathcRotation but specifically used for WheelColliders.
 */
    public class Wheel : MonoBehaviour
    {
        [SerializeField] private new WheelCollider collider;

        [Header("Debug")] 
        // Cache
        [SerializeField] private float rpm;

        [SerializeField] private float steerAngle;
        [SerializeField] private Quaternion rot;
        [SerializeField] private Vector3 pos;

        // Update is called once per frame
        void FixedUpdate()
        {
            rpm = collider.rpm;
            steerAngle = collider.steerAngle;
        
            // deltaTime is in seconds so we convert angular velocity from minutes to seconds.
            // transform.Rotate(rpm / 60 * Time.deltaTime * Vector3.right);
        
            // Gets Transform and rotation from the global coordinate
            // We just need the rotation
        
            collider.GetWorldPose(out pos ,out rot);
            transform.rotation = rot;
            transform.position = pos;
            // transform.position = temp;
            // transform.Rotate(steerAngle * Vector3.up);
        }
    }
}
