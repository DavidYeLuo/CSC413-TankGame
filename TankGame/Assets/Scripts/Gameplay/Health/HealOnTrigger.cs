using System.Collections;
using System.Collections.Generic;
using Gameplay.Health.Interfaces;
using UnityEngine;

public class HealOnTrigger : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private AudioSource audio;

    private void OnTriggerEnter(Collider collider)
    {
        if(audio != null)
            audio.Play();
        
        IHeal obj = collider.gameObject.GetComponent<IHeal>();
        if (obj == null) return;
        obj.Heal(value);
    }
}
