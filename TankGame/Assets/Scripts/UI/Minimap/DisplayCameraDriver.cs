using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class DisplayCameraDriver : MonoBehaviour
{
    private RenderTexture minimapAsset;
    private RawImage rawImage;

    public void Init(RenderTexture asset)
    {
        if(rawImage == null)
            rawImage = GetComponent<RawImage>();
        minimapAsset = asset;
        rawImage.texture = minimapAsset;
    }
}
