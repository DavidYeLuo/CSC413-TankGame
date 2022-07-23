using UnityEngine;

namespace Gameplay.Camera.Interfaces
{
    /**
     * Obsolete: Used in ThirdPersonCamera.cs but the project no longer uses it.
     */
    public interface IObjTransform : IObjLocation, IObjRotation
    {
        public Transform GetTransform();
    }
}