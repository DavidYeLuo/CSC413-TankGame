using InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Camera
{
    public class ThirdPersonCamera : MonoBehaviour
    {
        private InputAction mouseControl;

        private void Start()
        {
            mouseControl = InputDriver.GetControls().Gameplay.Look;
        }
        
    }
}