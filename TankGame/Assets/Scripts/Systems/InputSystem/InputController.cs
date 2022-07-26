using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.InputSystem
{
    [RequireComponent(typeof(InputDriver))]
    [RequireComponent(typeof(PlayerInputManager))]
    public class InputController : MonoBehaviour
    {
        [SerializeField] private InputDriver driver;
        private void OnEnable()
        {
            PlayerInputManager playerInputManager = PlayerInputManager.instance;
            playerInputManager.onPlayerJoined += OnPlayerJoin;
            playerInputManager.onPlayerLeft += OnPlayerLeft;
        }

        private void OnDisable()
        {
            PlayerInputManager playerInputManager = PlayerInputManager.instance;
            playerInputManager.onPlayerJoined -= OnPlayerJoin;
            playerInputManager.onPlayerLeft -= OnPlayerLeft;
        }

        private void OnPlayerJoin(PlayerInput input)
        {
            driver.AddControl(input);
        }

        private void OnPlayerLeft(PlayerInput input)
        {
            driver.RemoveControl(input.playerIndex);
        }
        
        private void Start()
        {
            SwitchMode(UserMode.UI);
        }

        // TODO: Make this a part of the driver class
        public void SwitchMode(UserMode mode)
        {
            switch (mode)
            {
                case UserMode.UI:
                    driver.SwitchToUIMode();
                    break;
                case UserMode.Gameplay:
                    driver.SwitchToGameplayMode();
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }
        }
    }
}