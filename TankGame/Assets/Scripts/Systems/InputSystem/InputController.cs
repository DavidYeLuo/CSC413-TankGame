using System;
using UnityEngine;

namespace Systems.InputSystem
{
    [RequireComponent(typeof(InputDriver))]
    public class InputController : MonoBehaviour
    {
        private static InputController instance;
        
        private InputDriver driver;

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