using Gameplay.Movement.Interfaces;
using Gameplay.Rotation.Interfaces;
using UnityEngine;

namespace Gameplay.Rotation
{
    public abstract class Rotator : MonoBehaviour, IRotateResponse
    {
        public abstract void Look(Vector2 direction);
    }
}