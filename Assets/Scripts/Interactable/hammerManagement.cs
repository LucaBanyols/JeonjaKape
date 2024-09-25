using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerManagement : MonoBehaviour
{
    public GameObject inttext, hammerObject, hammerPauseImage;
    public AudioSource pickup;
    public bool interactable;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if(interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inttext.SetActive(false);
                interactable = false;
                pickup.Play();
                hammerObject.SetActive(false);
                hammerPauseImage.SetActive(true);
            }
        }
    }
}
