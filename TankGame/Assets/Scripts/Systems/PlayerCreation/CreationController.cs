using System;
using System.Collections.Generic;
using Systems.PlayerCreation.Interfaces;
using UnityEngine;

namespace Systems.PlayerCreation
{
    [RequireComponent(typeof(PlayerCreationDriver))]
    public class CreationController : MonoBehaviour, IInitPlayerAsset
    {
        private PlayerCreationDriver driver;

        // We use Awake because InitPlayer can be called before Start()
        private void Awake()
        {
            driver = GetComponent<PlayerCreationDriver>();
        }

        public void InitPlayer(PlayerAsset asset)
        {
            driver.Init(asset);
        }
    }
}
