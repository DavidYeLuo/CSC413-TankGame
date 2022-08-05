using Systems.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace UI.Functions
{
    public class FunctionDriver : MonoBehaviour
    {
        [SerializeField] private SystemAsset systemAsset;
        [SerializeField] private Navigable startPanel;
        
        [Header("Driver(s)")]
        [SerializeField] private InputDriver inputDriver;
        
        [Header("For Debug purpose")] 
        [SerializeField] private Navigable currentPanel;
        [SerializeField] private Navigable previousPanel;
        protected virtual void Start()
        {
            if (startPanel == null) return;
            currentPanel = startPanel;
            // currentPanel.gameObject.SetActive(true);
        }
        
        public virtual void GotoPreviousPanel()
        {
            Navigate(previousPanel);
        }
        
        public virtual void Navigate(Navigable panel)
        {
            currentPanel.Navigate(panel);
            previousPanel = currentPanel;
            currentPanel = panel;
        }
        
        public virtual void SaveSystemAsset()
        {
            inputDriver.SavePlayersControl();
        }
        
        public virtual void EnablePlayerJoin()
        {
            PlayerInputManager.instance.EnableJoining();
        }

        public virtual void DisablePlayerJoin()
        {
            PlayerInputManager.instance.DisableJoining();
        }
        
        public virtual void ExitApplication()
        {
            Application.Quit();
        }
        
        public virtual void LoadScene(string scene)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }

        public virtual void SwitchToGameplayMode()
        {
            inputDriver.SwitchToGameplayMode();
        }
        public virtual void EnterGameplay()
        {
            // Switch scenes here.
            inputDriver.SwitchToGameplayMode();
        }
    }
}