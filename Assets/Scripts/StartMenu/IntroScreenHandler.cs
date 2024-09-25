using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScreenHandler : MonoBehaviour
{
    public GameObject mainMenuScreen;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            mainMenuScreen.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
