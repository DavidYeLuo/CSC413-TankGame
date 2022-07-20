using System;
using UnityEngine;

namespace Gameplay.Mesh
{
    public class MatchRotation : MonoBehaviour
    {
        // [SerializeField] private GameObject obj;
        [SerializeField] private Collider collider;

        private void FixedUpdate()
        {
            transform.rotation = collider.transform.rotation;
            // transform.rotation = obj.transform.rotation;
        }
    }
}