using UnityEngine;

namespace Gameplay.Camera.Interfaces
{
    public interface IObjTransform : IObjLocation, IObjRotation
    {
        public Transform GetTransform();
    }
}