using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public Animator transition;
    public string nextSceneName;
    public float transitionTime = 1f;

    public GameObject introScreen;
    public GameObject mainMenuScreen;
    public GameObject settingsScreen;
    // way to know which screen is active
    private bool isIntroScreenActive = true;
    private bool isMainMenuScreenActive = false;
    private bool isSettingsScreenActive = false;

    void Update()
    {
        if (isIntroScreenActive)
        {
            if (Input.anyKey)
            {
                introScreen.SetActive(false);
                mainMenuScreen.SetActive(true);
                isIntroScreenActive = false;
                isMainMenuScreenActive = true;
            }
        }
        else if (isMainMenuScreenActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                mainMenuScreen.SetActive(false);
                settingsScreen.SetActive(true);
                isMainMenuScreenActive = false;
                isSettingsScreenActive = true;
            }
        }
        else if (isSettingsScreenActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                settingsScreen.SetActive(false);
                mainMenuScreen.SetActive(true);
                isSettingsScreenActive = false;
                isMainMenuScreenActive = true;
            }
        }
    }

    public void LoadNextScene()
    {
        if (nextSceneName != "")
        {
            StartCoroutine(LoadSceneByIndex(nextSceneName));
        }
    }

    IEnumerator LoadSceneByIndex(string scene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(scene);
    }
}
