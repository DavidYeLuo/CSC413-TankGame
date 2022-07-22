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
        private static InputController instance;
        
        private InputDriver driver;
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
            driver.AddControl(input.playerIndex, input);
        }

        private void OnPlayerLeft(PlayerInput input)
        {
            driver.RemoveControl(input.playerIndex);
        }

        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                return;
            }
            Destroy(this);
        }

        private void Start()
        {
            instance.driver = GetComponent<InputDriver>();
            SwitchMode(UserMode.UI);
        }

        public static void SwitchMode(UserMode mode)
        {
            switch (mode)
            {
                case UserMode.UI:
                    instance.driver.SwitchToUIMode();
                    break;
                case UserMode.Gameplay:
                    instance.driver.SwitchToGameplayMode();
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }
        }
    }
}