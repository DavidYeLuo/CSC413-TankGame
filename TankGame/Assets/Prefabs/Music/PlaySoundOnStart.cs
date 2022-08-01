using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        audioSource.Play();
    }
}
