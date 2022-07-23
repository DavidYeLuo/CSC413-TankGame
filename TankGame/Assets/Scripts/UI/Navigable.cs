using UI.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace UI
{
    public class Navigable : MonoBehaviour
    {
        public void Navigate(Navigable to)
        {
            to.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}