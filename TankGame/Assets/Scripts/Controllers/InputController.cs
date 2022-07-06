using System;
using System.Collections;
using Drivers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
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

        private IEnumerator Start()
        {
            driver = GetComponent<InputDriver>();
            yield return new WaitForSeconds(3);
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