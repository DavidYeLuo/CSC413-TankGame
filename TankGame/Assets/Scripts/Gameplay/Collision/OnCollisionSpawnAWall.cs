using UnityEngine;

namespace Gameplay.Collision
{
    // TODO: Find a better name for this class. (More generic name)
    // Don't need to rename it if we are only using it for one purpose: Spawn a wall on impact.
    public class OnCollisionSpawnAWall : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private bool destroyOnCollision;

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            ContactPoint contactPoint = collision.contacts[0];
            Vector3 planeNormal = Vector3.ProjectOnPlane(transform.forward, collision.contacts[0].normal);
            Instantiate(prefab, contactPoint.point, Quaternion.LookRotation(planeNormal,contactPoint.normal));
            if(destroyOnCollision)
                Destroy(this.gameObject);
        }
    }
}
