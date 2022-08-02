using System;
using Gameplay.Mesh.Interfaces;
using UnityEngine;

namespace Gameplay.Mesh
{
    public class TakePowerUpInvisible : MonoBehaviour, ICanBeInvisible
    {
        [SerializeField] private InvisibleDriver driver;
        public event InvisibleDriver.cooldownOver cooldownOverEvent;

        private void OnEnable()
        {
            driver.cooldownOverEvent += OnCooldownOver;
        }

        private void OnDisable()
        {
            driver.cooldownOverEvent -= OnCooldownOver;
        }

        public void BeInvisible(float seconds)
        {
            driver.BeInvisible(seconds);
        }

        private void OnCooldownOver()
        {
            if (cooldownOverEvent == null) return;
            cooldownOverEvent.Invoke();
        }
    }
}