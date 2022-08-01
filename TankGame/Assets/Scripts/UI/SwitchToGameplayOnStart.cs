using Systems.InputSystem;
using UnityEngine;

namespace UI
{
    public class SwitchToGameplayOnStart : MonoBehaviour
    {
        [SerializeField] private InputDriver inputDriver;

        private void Start()
        {
            inputDriver.SwitchToGameplayMode();
        }
    }
}