using Gameplay.Mesh.Interfaces;
using UnityEngine;

namespace Gameplay.Mesh.Receptors
{
    public class InvisibilityPowerUpReceptor : MonoBehaviour, ICanBeInvisible
    {
        [SerializeField] private InvisibilityDriver driver;
        public event InvisibilityDriver.cooldownOver cooldownOverEvent;

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