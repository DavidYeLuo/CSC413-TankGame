using System;
using Gameplay.Health;
using UnityEngine;

namespace Gameplay.Destroy
{
    public class DestroyOnDeath : MonoBehaviour
    {
        [SerializeField] private HealthDriver healthDriver;

        // Subscribe event
        private void OnEnable()
        {
            healthDriver.OnDeath += OnObjectDeath;
        }

        // Unsubscribe event
        private void OnDisable()
        {
            healthDriver.OnDeath -= OnObjectDeath;
        }
        
        private void OnObjectDeath()
        {
            Destroy(this.gameObject);
        }
    }
}