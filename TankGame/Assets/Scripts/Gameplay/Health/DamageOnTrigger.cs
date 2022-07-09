using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Health
{
    public class DamageOnTrigger : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private bool destroyOnTrigger;
        
        private HealthController controller;
        private void OnTriggerEnter(Collider collider)
        {
            if (HealthController.TryAndGet(collider.gameObject, out controller))
            {
                controller.SubtractHealth(damage);
                if (destroyOnTrigger)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}