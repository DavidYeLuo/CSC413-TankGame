using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Health
{
    public class DamageOnTrigger : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private bool destroyOnTrigger;
        
        private void OnTriggerEnter(Collider collider)
        {
            ITakeDamage obj = collider.gameObject.GetComponent<ITakeDamage>();
            if (obj == null) return;
            obj.TakeDamage(damage);
            if(destroyOnTrigger) gameObject.SetActive(false);
        }
    }
}