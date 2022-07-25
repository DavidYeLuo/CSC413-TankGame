using System;
using UnityEngine;

namespace Gameplay.Mesh
{
    public class MatchRotation : MonoBehaviour
    {
        [SerializeField] private Collider collider;

        private void FixedUpdate()
        {
            transform.rotation = collider.transform.rotation;
        }
    }
}