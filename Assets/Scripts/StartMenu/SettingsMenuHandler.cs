using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuHandler : MonoBehaviour
{
    public GameObject mainMenuScreen;
    public GameObject settingsScreen;

    public void ChangeScreen()
    {
        settingsScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
    }
}
