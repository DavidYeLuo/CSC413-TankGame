using UnityEngine;

namespace Gameplay.Movement
{
    public abstract class Rotator : MonoBehaviour
    {
        public abstract void Look(Vector2 direction);
    }
}