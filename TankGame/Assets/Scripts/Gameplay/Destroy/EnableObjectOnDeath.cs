using System;
using Gameplay.Health;
using ScriptableObjects;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;

namespace Gameplay.Destroy
{
    public class EnableObjectOnDeath : MonoBehaviour, IRequirePlayerAsset
    {
        [SerializeField] private IntReference health;

        private void OnEnable()
        {
            // Subscribe
            health.valueChangeEvent += OnObjectDeath;
        }
        
        private void OnDisable()
        {
            // Unsubscribe
            health.valueChangeEvent -= OnObjectDeath;
        }

        public void GetPlayerAsset(PlayerAsset asset)
        {
            if(health == null)
                health.valueChangeEvent -= OnObjectDeath;
            health = asset.GetHealthAsset();
            health.valueChangeEvent += OnObjectDeath;
        }
        private void OnObjectDeath()
        {
            if(health.GetValue() == 0)
                gameObject.SetActive(true);
        }
    }
}