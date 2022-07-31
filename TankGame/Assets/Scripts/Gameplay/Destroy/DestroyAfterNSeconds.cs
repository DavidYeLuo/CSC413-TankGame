using UnityEngine;

namespace Gameplay.Destroy
{
    public class DestroyAfterNSeconds : MonoBehaviour
    {
        [SerializeField] private float seconds;
        private void Start()
        {
            Destroy(this.gameObject, seconds);
        }
    }
}