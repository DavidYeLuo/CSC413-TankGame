using UnityEngine;

namespace Gameplay.Camera
{
    public interface IObjTransform : IObjLocation, IObjRotation
    {
        public Transform GetTransform();
    }
}