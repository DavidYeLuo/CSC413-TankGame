using Gameplay.Camera.Interfaces;
using UnityEngine;

namespace Gameplay.Camera
{
    /**
     * Obsolete: Planned to use it in ThirdPersonCamera.cs but the project no longer uses it.
     */
    public class ObjectToStare : MonoBehaviour, IObjTransform
    {
        [SerializeField] private GameObject objectLocation;
        
        public Vector3 GetPosition()
        {
            return objectLocation.transform.localPosition;
        }

        public Quaternion GetRotation()
        {
            return objectLocation.transform.rotation;
        }

        public Transform GetTransform()
        {
            return objectLocation.transform;
        }
    }
}