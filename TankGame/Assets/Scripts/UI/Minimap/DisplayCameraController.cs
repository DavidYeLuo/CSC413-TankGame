using System;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;

namespace UI.Minimap
{
    [RequireComponent(typeof(DisplayCameraDriver))]
    public class DisplayCameraController : MonoBehaviour, IRequirePlayerAsset
    {
        private DisplayCameraDriver driver;
        private RenderTexture minimapAsset;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            if(driver == null)
                driver = GetComponent<DisplayCameraDriver>();
            if(minimapAsset != null)
                driver.Init(minimapAsset);
        }

        public void GetPlayerAsset(PlayerAsset asset)
        {
            minimapAsset = asset.GetMinimap();
            Init();
        }
    }
}