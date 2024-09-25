using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject mainPauseMenu;
    [SerializeField] GameObject settingsMenu;

    private bool isMain = true;
    private bool isSettings = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSettings == true)
            {
                OpenMainPauseMenu();
            }
        }
    }

    public void OpenMainPauseMenu()
    {
        isMain = true;
        isSettings = false;
        mainPauseMenu.SetActive(isMain);
        settingsMenu.SetActive(isSettings);
    }

    public void OpenSettingsMenu()
    {
        isMain = false;
        isSettings = true;
        mainPauseMenu.SetActive(isMain);
        settingsMenu.SetActive(isSettings);
    }
}
