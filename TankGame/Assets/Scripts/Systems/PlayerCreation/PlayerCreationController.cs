using System;
using System.Collections.Generic;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;

namespace Systems.PlayerCreation
{
    [RequireComponent(typeof(PlayerCreationDriver))]
    public class PlayerCreationController : MonoBehaviour, IInitPlayerAsset
    {
        private PlayerCreationDriver driver;
        [SerializeField] private PlayerAsset playerAsset;

        // We use Awake because InitPlayer can be called before Start()
        private void Start()
        {
            Init(playerAsset);
        }

        private void Init(PlayerAsset asset)
        {
            if(driver == null)
                driver = GetComponent<PlayerCreationDriver>();
            driver.Init(asset);
        }

        public void InitPlayer(PlayerAsset asset)
        {
            playerAsset = asset;
            Init(playerAsset);
        }
    }
}
