using System;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Functions
{
    public class TextFieldSetting : MonoBehaviour
    {
        [SerializeField] private TMP_InputField textField;

        public void SetFloat(FloatReference floatReference)
        {
            float temp;
            float.TryParse(textField.text, out temp);
            Debug.LogFormat("Textfield: {0}, temp: {1}", textField.text, temp);
            if(temp != null)
            {
                floatReference.SetValue(temp);
                return;
            }
            textField.text = String.Empty;
        }
    }
}