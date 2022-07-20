using UnityEngine;

namespace Systems.InputSystem
{
    public class InputDriver : MonoBehaviour
    {
        public delegate void changeMode(UserMode _mode);
        public static event changeMode changeModeEvent;

        private static InputDriver instance;
        
        [SerializeField] private UserMode mode;

        private static PlayerControls controls; // Other classes will use this

        private void Awake()
        {
            if (instance == null)
            {
                controls = new PlayerControls();
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void OnEnable()
        {
            controls.Enable();
        }

        private void OnDisable()
        {
           controls.Disable(); 
        }

        public static PlayerControls GetControls()
        {
            return controls;
        }

        public void SwitchToUIMode()
        {
            controls.UI.Enable();
            controls.Gameplay.Disable();
            mode = UserMode.UI;

            if (changeModeEvent == null) return;
            changeModeEvent.Invoke(mode);
            
            // Cursor.lockState = CursorLockMode.None; // TODO: Do testing on locking cursor
        }

        public void SwitchToGameplayMode()
        {
            controls.UI.Disable();
            controls.Gameplay.Enable();
            mode = UserMode.Gameplay;
            
            if (changeModeEvent == null) return;
            changeModeEvent.Invoke(mode);
        }
        
        // TODO: Do testing on locking cursor
        // private void OnApplicationFocus(bool hasFocus)
        // {
        //     if(hasFocus && mode == UserMode.Gameplay)
        //         Cursor.lockState = CursorLockMode.Confined;
        // }
    }
    public enum UserMode 
    {
        UI,
        Gameplay
    }
}