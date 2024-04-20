using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChangeFunction : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    public void ChangeVolume()
    {
        AudioListener.volume = slider.value;
    }
}