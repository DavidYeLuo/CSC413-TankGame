using System;
using UnityEngine;

namespace Gameplay.Destroy
{
    public class DestroyOnCollision : MonoBehaviour
    {
        private void OnCollisionStay(UnityEngine.Collision collisionInfo)
        {
            Destroy(this.gameObject);
        }
    }
}