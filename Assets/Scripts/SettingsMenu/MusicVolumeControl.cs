using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class MusicVolumeControl : MonoBehaviour
{
    // We use a SerializedField so that we can see the variable in the inspector
    [SerializeField] Slider musicVolumeSlider;
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1f);
            Save();
        }
        else
        {
            Load();
        }
    }

    public void SetMusicVolume()
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(musicVolumeSlider.value) * 20);
        Save();
    }

    private void Load()
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume", 1f)) * 20);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
    }
}
