using UnityEngine;

namespace Gameplay.Movement.Interfaces
{
    public interface IPushable
    {
        public void AddForce(Vector3 force);
    }
}