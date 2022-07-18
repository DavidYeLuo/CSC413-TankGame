using Gameplay.Camera.Interfaces;
using UnityEngine;

namespace Gameplay.Camera
{
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