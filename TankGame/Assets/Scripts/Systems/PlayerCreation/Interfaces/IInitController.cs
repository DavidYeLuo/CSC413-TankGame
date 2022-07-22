using UnityEngine.InputSystem;

namespace Systems.PlayerCreation.Interfaces
{
    public interface IInitController
    {
        public void InitController(PlayerInput playerInput);
    }
}