using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject introScreen = default;
    public GameObject mainMenuScreen;
    public GameObject settingsScreen;

    public void ChangeScreen(string screenName)
    {
        if (screenName == "Intro")
        {
            mainMenuScreen.SetActive(false);
            introScreen.SetActive(true);
        }
        else if (screenName == "Settings")
        {
            mainMenuScreen.SetActive(false);
            settingsScreen.SetActive(true);
        }
    }
}
