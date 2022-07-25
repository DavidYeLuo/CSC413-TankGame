using Gameplay.Movement.Interfaces;
using UnityEngine;

namespace Gameplay.Movement
{
    public abstract class Movement : MonoBehaviour, IMoveResponse
    {
        public abstract void Move(Vector2 direction);
    }
}