using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "DataReference/FloatReference", fileName = "FloatReference")]
    public class FloatReference : ScriptableObject
    {
        public delegate void valueChanged();
        public event valueChanged valueChangeEvent;
    
        [SerializeField] private float value;
    
        [SerializeField] private float initValue;

        /**
         * Value persist when working with the editor.
         * Doesn't matter for a built project but annoying in the developing process
         * TODO: Removed OnEnable method on release
         */
        public void OnEnable()
        {
            value = initValue;
        }

        public void SetValue(float val)
        {
            this.value = val;
            if(valueChangeEvent == null) return;
            valueChangeEvent.Invoke();
        }

        public float GetValue()
        {
            return value;
        }
    }
}