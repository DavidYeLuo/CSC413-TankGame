using System;
using Gameplay.Health.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Gameplay.Health
{
    public class DamageOnTrigger : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private bool destroyOnTrigger;
        [SerializeField] private AudioSource audio;

        private void OnTriggerEnter(Collider collider)
        {
            audio.Play();
            
            ITakeDamage obj = collider.gameObject.GetComponent<ITakeDamage>();
            if (obj == null) return;
            obj.TakeDamage(damage);
        }
    }
}