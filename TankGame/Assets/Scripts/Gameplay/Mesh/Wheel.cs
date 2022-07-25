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
        // Cache (Hopefully avoid creating too much garbage)
        [SerializeField] private Quaternion rot;
        [SerializeField] private Vector3 pos;

        // Update is called once per frame
        void FixedUpdate()
        {
            collider.GetWorldPose(out pos ,out rot);
            transform.rotation = rot;
            transform.position = pos;
        }
    }
}
