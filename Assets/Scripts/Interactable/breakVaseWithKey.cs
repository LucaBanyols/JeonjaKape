using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakVaseWithKey : MonoBehaviour
{
    public GameObject vaseObject, exitKey, inttext, hammerPicture, textVase;
    public AudioSource pickup;
    public bool interactable;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (hammerPicture.activeSelf) {
                inttext.SetActive(true);
                interactable = true;
            }
            else
            {
                textVase.SetActive(true);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
            textVase.SetActive(false);
        }
    }
    void Update()
    {
        if(interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hammerPicture.activeSelf) {
                    pickup.Play();
                    vaseObject.SetActive(false);
                    inttext.SetActive(false);
                    interactable = false;
                    exitKey.SetActive(true);
                }
            }
        }
    }
}
