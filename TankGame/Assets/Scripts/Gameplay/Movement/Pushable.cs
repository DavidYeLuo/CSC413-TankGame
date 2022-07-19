using System;
using Gameplay.Movement.Interfaces;
using UnityEngine;

namespace Gameplay.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Pushable : MonoBehaviour, IPushable
    {
        private Rigidbody rb;
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void AddForce(Vector3 force)
        {
            rb.AddForce(force, ForceMode.Force);
        }
    }
}