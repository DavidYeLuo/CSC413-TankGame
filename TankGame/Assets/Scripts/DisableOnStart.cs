using UnityEngine;

namespace DefaultNamespace
{
    public class DisableOnStart : MonoBehaviour
    {
        private void Start()
        {
            gameObject.SetActive(false);
        }
    }
}