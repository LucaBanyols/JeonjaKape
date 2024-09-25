using System.Collections;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void onClick(string sceneName)
    {
        LoadNextScene(sceneName);
    }

    public void LoadNextScene(string sceneName)
    {
        if (sceneName == "Settings")
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (sceneName == "StartMenu")
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (sceneName != "")
        {
            StartCoroutine(LoadSceneByIndex(sceneName));
        }
    }

    IEnumerator LoadSceneByIndex(string scene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(scene);
    }
}
