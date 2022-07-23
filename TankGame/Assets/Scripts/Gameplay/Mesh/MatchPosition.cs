using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Mesh
{
    public class MatchPosition : MonoBehaviour
    {
        [SerializeField] private Collider collider;

        private void FixedUpdate()
        {
            transform.position = collider.transform.position;
        }
    }
}