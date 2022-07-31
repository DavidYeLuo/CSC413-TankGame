using Systems.PlayerCreation.Interfaces;
using UnityEngine;

namespace Systems.PlayerCreation.AttachToPlayer
{
    [RequireComponent(typeof(CreationDriver))]
    public class PlayerCreationController : MonoBehaviour, IInitPlayerAsset
    {
        private CreationDriver driver;
        [SerializeField] private PlayerAsset playerAsset;

        // We use Awake because InitPlayer can be called before Start()
        private void Start()
        {
            Init(playerAsset);
        }

        private void Init(PlayerAsset asset)
        {
            if(driver == null)
                driver = GetComponent<CreationDriver>();
            driver.Init(asset);
        }

        public void InitPlayer(PlayerAsset asset)
        {
            playerAsset = asset;
            Init(playerAsset);
        }
    }
}