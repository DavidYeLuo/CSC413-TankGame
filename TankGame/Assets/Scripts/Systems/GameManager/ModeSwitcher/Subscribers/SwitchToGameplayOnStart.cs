using Systems.InputSystem;
using UnityEngine;

namespace Systems.GameManager.ModeSwitcher.Subscribers
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