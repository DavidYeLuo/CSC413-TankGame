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
        [SerializeField] private AudioSource audio;

        private void OnTriggerEnter(Collider collider)
        {
            if(audio != null)
                audio.Play();
            
            ITakeDamage obj = collider.gameObject.GetComponent<ITakeDamage>();
            if (obj == null) return;
            obj.TakeDamage(damage);
        }
    }
}