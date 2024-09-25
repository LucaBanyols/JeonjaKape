using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TriggerAnimationMonster : MonoBehaviour
{
    public Animator changePositionMonster;
    public float transitionTimeMonster = 4f;

    public Animator transition;
    public float transitionTime = 1f;
    
    public RectTransform startButton;
    public RectTransform settingsButton;
    public RectTransform quitButton;

    public void onClick(string scene)
    {
        StartCoroutine(AnimateMonster(scene));
    }

    IEnumerator AnimateMonster(string scene)
    {
        changePositionMonster.SetTrigger("ChangePosition");
        /* startButton.GetComponent<Animator>().Play("SlideFadeStartButton");
        settingsButton.GetComponent<Animator>().Play("SlideFadeSettingsButton");
        quitButton.GetComponent<Animator>().Play("SlideFadeQuitButton"); */

        yield return new WaitForSeconds(transitionTimeMonster);
        
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(scene);
    }
}
