using System;
using System.Collections.Generic;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;

namespace Systems.PlayerCreation
{
    public class PlayerCreationDriver : MonoBehaviour
    {
        [SerializeField] protected PlayerAsset playerAsset;
        
        private List<IRequirePlayerAsset> deviceControllers;

        private void Start()
        {
            if (playerAsset == null) return;
            Init(playerAsset);
        }

        public virtual void Init(PlayerAsset asset)
        {
            playerAsset = asset;
            
            if (playerAsset == null)
            {
                throw new Exception("CreationController: Player asset is empty");
            }
            
            deviceControllers = GetListOfReqInterfaces();

            if (deviceControllers == null)
            {
                throw new Exception(String.Format("Player Asset: {0}, device controllers: {1}", playerAsset != null,
                    deviceControllers != null));
            }
            
            foreach (var deviceController in deviceControllers)
            {
                deviceController.GetPlayerAsset(playerAsset);
            }
        }
        
        private List<IRequirePlayerAsset> GetListOfReqInterfaces()
        {
            return new List<IRequirePlayerAsset>(gameObject.GetComponentsInChildren<IRequirePlayerAsset>());
        }
    }
}