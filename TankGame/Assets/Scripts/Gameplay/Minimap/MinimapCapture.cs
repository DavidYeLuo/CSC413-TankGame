using System;
using System.Collections;
using System.Collections.Generic;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Camera))]
public class MinimapCapture : MonoBehaviour, IRequirePlayerAsset
{
    [SerializeField] private RenderTexture minimapAsset;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        if (minimapAsset == null) return;
        cam.targetTexture = minimapAsset;
    }

    public void GetPlayerAsset(PlayerAsset asset)
    {
        minimapAsset = asset.GetMinimap();
    }
}
