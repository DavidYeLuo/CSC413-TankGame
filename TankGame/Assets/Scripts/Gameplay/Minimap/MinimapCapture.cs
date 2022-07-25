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

    public void GetPlayerAsset(PlayerAsset asset)
    {
        minimapAsset = asset.GetMinimap();
        GetComponent<Camera>().targetTexture = minimapAsset;
    }
}
