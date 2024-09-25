using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuSFXVolumeControl : MonoBehaviour
{
    // We use a SerializedField so that we can see the variable in the inspector
    [SerializeField] Slider sfxVolumeSlider;
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("MenuEffectsVolume"))
        {
            PlayerPrefs.SetFloat("MenuEffectsVolume", 1f);
            Save();
        }
        else
        {
            Load();
        }
    }

    public void SetSFXVolume()
    {
        mixer.SetFloat("MenuEffectsVolume", Mathf.Log10(sfxVolumeSlider.value) * 20);
        Save();
    }

    private void Load()
    {
        mixer.SetFloat("MenuEffectsVolume", Mathf.Log10(PlayerPrefs.GetFloat("MenuEffectsVolume", 1f)) * 20);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("MenuEffectsVolume", 1f);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("MenuEffectsVolume", sfxVolumeSlider.value);
    }
}
