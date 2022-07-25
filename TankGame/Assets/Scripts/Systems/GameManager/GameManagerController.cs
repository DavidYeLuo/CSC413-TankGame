using System;
using UnityEngine;

namespace Systems.GameManager
{
    public class GameManagerController : MonoBehaviour
    {
        [SerializeField] private GameManagerDriver driver;

        private void Start()
        {
            driver.CreatePlayers();
        }
    }
}