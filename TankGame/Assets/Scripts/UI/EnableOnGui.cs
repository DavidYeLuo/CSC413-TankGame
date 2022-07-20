using System;
using Systems.InputSystem;
using UnityEngine;

namespace UI
{
    public class EnableOnGui : MonoBehaviour
    {
        private void Start()
        {
            InputDriver.changeModeEvent += OnModeChange;
        }

        private void OnModeChange(UserMode mode)
        {
            if (mode == UserMode.UI)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
