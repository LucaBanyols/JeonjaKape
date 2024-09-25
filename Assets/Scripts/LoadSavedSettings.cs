using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class LoadSavedSettings : MonoBehaviour
{
    public AudioMixer MainMixer;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (!PlayerPrefs.HasKey("MasterVolume") && !PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MasterVolume", 1f);
            PlayerPrefs.SetFloat("MusicVolume", 1f);
            PlayerPrefs.SetFloat("MenuEffectsVolume", 1f);
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat("MasterVolume", 1f);
            MainMixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume", 1f)) * 20);
            MainMixer.SetFloat("MenuEffectsVolume", Mathf.Log10(PlayerPrefs.GetFloat("MenuEffectsVolume", 1f)) * 20);
        }
    }
}
