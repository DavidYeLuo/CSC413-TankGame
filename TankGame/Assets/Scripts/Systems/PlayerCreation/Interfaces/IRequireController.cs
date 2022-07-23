using UnityEngine.InputSystem;

namespace Systems.PlayerCreation.Interfaces
{
    public interface IRequireController
    {
        public void GetController(InputActionMap map);
    }
}