using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ContextTexts : MonoBehaviour
{
    public string[] texts;
    public TextMeshProUGUI displayedText;
    public float waitingTime = 10f;
    public int transitionTime = 1;
    public string scene = "Sean's map";

    private int currentTextIndex = 0;

    void Start()
    {
        StartCoroutine(Fade());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentTextIndex++;
            if (currentTextIndex >= texts.Length)
            {
                ChangeScene();
            }
            else
            {
                StartCoroutine(Fade());
            }
        }
    }

    private IEnumerator Fade()
    {
        bool loop = true;

        while (loop)
        {
            if (currentTextIndex < texts.Length)
            {
                displayedText.text = texts[currentTextIndex];

                displayedText.GetComponent<Animator>().Play("Fade Out");

                yield return new WaitForSeconds(waitingTime);

                displayedText.GetComponent<Animator>().Play("Fade In");

                currentTextIndex += 1;

                yield return new WaitForSeconds(transitionTime);

                if (currentTextIndex == texts.Length)
                {
                    loop = false;
                }
            }
        }

        if (loop == false)
        {
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(scene);
    }
}
