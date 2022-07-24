using UnityEngine;

namespace UI.Functions
{
    public class FunctionController : MonoBehaviour
    {
        [Header("Driver")]
        // Used to get device to play
        [SerializeField] private FunctionDriver managerDriver;

        public void GotoPreviousPanel()
        {
            managerDriver.GotoPreviousPanel();
        }

        public void Navigate(Navigable panel)
        {
            managerDriver.Navigate(panel);
        }

        public void SaveSystemAsset()
        {
            managerDriver.SaveSystemAsset();
        }

        public void EnablePlayerJoin()
        {
            managerDriver.EnablePlayerJoin();
        }

        public void DisablePlayerJoin()
        {
            managerDriver.DisablePlayerJoin();
        }

        public void ExitApplication()
        {
            managerDriver.ExitApplication();
        }

        public void LoadScene(string scene)
        {
            managerDriver.LoadScene(scene);
        }
    
        public void EnterGameplay()
        {
            managerDriver.EnterGameplay();
        }
    }
}
