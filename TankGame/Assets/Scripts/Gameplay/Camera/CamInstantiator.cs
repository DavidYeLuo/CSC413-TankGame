using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Camera;
using UnityEngine;

// TODO: This is currently a temporary solution to adding a camera to a game object.
// We still need to figure out how we are going to deal with multiple player.
public class CamInstantiator : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject cameraLocation;

    private void Start()
    {
        // Developer warning
        if(cameraLocation.GetComponent<CameraLocation>() == null) Debug.Log("CamInstantiator: camera location isn't a type CameraLocation");
        
        // Sets the camera's transform to be the same as the location's transform.
        cam.transform.position = cameraLocation.transform.position;
        cam.transform.rotation = cameraLocation.transform.rotation;
        
        // Attach the camera to the cameraLocation gameObject
        cam.transform.SetParent(cameraLocation.transform);
    }
}
