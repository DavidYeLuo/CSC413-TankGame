using System;
using UnityEngine.InputSystem;

namespace Systems.PlayerCreation.Helpers
{
    public static class InputActionHelper
    {
        public static InputAction GetInputAction(InputActionMap map, string actionName)
        {
            if (map == null) throw new Exception("InputActionHelper.GetInputAction map is null.");
            // Again, ugly code but see GetMap method in InputCreationController.cs for explanation
            InputAction result = map.FindAction(actionName);
            if (result == null) throw new Exception("InputCreationController: Player InputAction isn't found.");
            return result;
        }
    }
}