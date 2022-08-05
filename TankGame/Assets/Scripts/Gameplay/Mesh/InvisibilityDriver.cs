using System.Collections;
using Gameplay.Mesh.Interfaces;
using UnityEngine;

namespace Gameplay.Mesh
{
    /**
     * Deactivate the gameObject for the an amount of seconds
     */
    public class InvisibilityDriver : MonoBehaviour, IBeInvisibleResponse
    {
        [SerializeField] private GameObject objToBeInvisible;
        [Header("Debug")] 
        [SerializeField] private bool isInvisible;

        public delegate void cooldownOver();
        public event cooldownOver cooldownOverEvent;

        /**
         * We are implementing using a coroutine
         */
        private IEnumerator DeactivateGameObject(float seconds)
        {
            objToBeInvisible.SetActive(false);
            yield return new WaitForSeconds(seconds);
            
            objToBeInvisible.SetActive(true);
            if (cooldownOverEvent != null)
            {
                cooldownOverEvent.Invoke();
            }
        }

        public void BeInvisible(float seconds)
        {
            if (isInvisible) return;
            StartCoroutine(DeactivateGameObject(seconds));
        }
    }
}