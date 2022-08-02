using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class OnCollisionSpawnAWall : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private bool destroyOnCollision;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Called!");
        ContactPoint contactPoint = collision.contacts[0];
        Vector3 planeNormal = Vector3.ProjectOnPlane(transform.forward, collision.contacts[0].normal);
        Instantiate(prefab, contactPoint.point, Quaternion.LookRotation(planeNormal,contactPoint.normal));
        if(destroyOnCollision)
            Destroy(this.gameObject);
    }
}
