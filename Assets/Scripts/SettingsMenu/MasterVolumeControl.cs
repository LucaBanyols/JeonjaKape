using System;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolumeControl : MonoBehaviour
{
    // We use a SerializedField so that we can see the variable in the inspector
    [SerializeField] Slider masterVolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("MasterVolume"))
        {
            PlayerPrefs.SetFloat("MasterVolume", 1f);
            Save();
        }
        else
        {
            Load();
        }
    }

    public void SetMasterVolume()
    {
        AudioListener.volume = masterVolumeSlider.value;
        Save();
    }

    private void Load()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        AudioListener.volume = masterVolumeSlider.value;
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
    }
}
