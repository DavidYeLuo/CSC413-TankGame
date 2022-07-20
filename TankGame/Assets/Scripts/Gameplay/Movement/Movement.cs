using UnityEngine;

namespace Gameplay.Movement
{
    public abstract class Movement : MonoBehaviour
    {
        public abstract void Move(Vector2 direction);
    }
}