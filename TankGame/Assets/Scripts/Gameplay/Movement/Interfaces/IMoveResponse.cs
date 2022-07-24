using UnityEngine;

namespace Gameplay.Movement.Interfaces
{
    public interface IMoveResponse
    {
        public void Move(Vector2 direction);
    }
}