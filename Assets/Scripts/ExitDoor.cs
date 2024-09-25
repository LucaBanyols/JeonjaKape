using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    public GameObject inttext;
    public GameObject textClose;
    public GameObject isKeyExitInPause;
    public bool interactable;
    public string scene;

    void OnTriggerStay(Collider other)
    {
        if (isKeyExitInPause.activeSelf) {
            if (other.CompareTag("MainCamera"))
            {
                inttext.SetActive(true);
                interactable = true;
            }
        } else {
            if (other.CompareTag("MainCamera"))
            {
                textClose.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            textClose.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if(interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
}
