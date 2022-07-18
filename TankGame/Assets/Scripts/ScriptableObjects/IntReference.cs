using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "DataReference/IntReference", fileName = "IntReference")]
    [System.Serializable]
    public class IntReference : ScriptableObject
    {
        public delegate void valueChanged();
        public event valueChanged valueChangeEvent;
    
        [SerializeField] private int value;
        [SerializeField] private int initValue;

        /**
         * Value persist when working with the editor.
         * Doesn't matter for a built project but annoying in the developing process
         * TODO: Removed OnEnable method on release
         */
        public void OnEnable()
        {
            value = initValue;
        }

        public void SetValue(int val)
        {
            this.value = val;
            if (valueChangeEvent == null) return;
            valueChangeEvent.Invoke();
        }

        public int GetValue()
        {
            return value;
        }
        
    }
}