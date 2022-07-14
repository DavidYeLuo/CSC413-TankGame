using UnityEngine;

namespace Gameplay.Movement
{
    public abstract class MovementDriver : MonoBehaviour
    {
        public abstract void Move(Vector2 direction);
    }
}