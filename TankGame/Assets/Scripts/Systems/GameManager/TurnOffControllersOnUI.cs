using System.Collections.Generic;
using Systems.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.GameManager
{
    public class TurnOffControllersOnUI: MonoBehaviour
    {
        [SerializeField] private SystemAsset systemAsset;
        private void OnEnable()
        {
            InputDriver.changeModeEvent += TurnOff;
        }

        private void OnDisable()
        {
            InputDriver.changeModeEvent -= TurnOff;
        }

        private void TurnOff(UserMode mode)
        {
            if (mode != UserMode.UI) return;
            List<PlayerInput> controllers = systemAsset.GetPlayerInputs();
            foreach (PlayerInput controller in controllers)
            {
                controller.currentActionMap.Disable();
            }
        }
    }
}