using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private Slider volumeSlider;
    private void Start()
    {
        audioSources = FindObjectsOfType<AudioSource>();
        if (PlayerPrefs.HasKey("VolumeSlider"))
        {
            foreach (var audioSource in audioSources)
            {
                audioSource.volume = PlayerPrefs.GetFloat("VolumeSlider");
            }
            volumeSlider.value = PlayerPrefs.GetFloat("VolumeSlider");
        }
    }

    public void OnSliderValueChange()
    {
        PlayerPrefs.SetFloat("VolumeSlider", volumeSlider.value);
        foreach (var audioSource in audioSources)
        {
            audioSource.volume = PlayerPrefs.GetFloat("VolumeSlider");
        }
    }
}