using System;
using System.Collections;
using Gameplay.Mesh;
using Gameplay.Mesh.Interfaces;
using UnityEngine;

namespace Gameplay.Collision
{
    public class OnTriggerInvisible : MonoBehaviour
    {
        [SerializeField] private float seconds;
        
        [SerializeField] private AudioSource audio;

        private void OnTriggerEnter(Collider other)
        {
            if(audio != null)
                audio.Play();
            
            ICanBeInvisible obj = other.gameObject.GetComponent<ICanBeInvisible>();
            if (obj == null) return;
            obj.BeInvisible(seconds);
        }
    }
}