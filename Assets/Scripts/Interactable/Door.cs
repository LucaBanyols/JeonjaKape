using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject inttext;
    public bool interactable, toggle;
    public AudioSource doorOpen;
    public AudioSource doorClose;
    public Animator doorAnim;

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
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;
                if (toggle == true)
                {
                    doorOpen.Play();
                    doorAnim.ResetTrigger("Close");
                    doorAnim.SetTrigger("Open");
                }

                if (toggle == false)
                {
                    doorClose.Play();
                    doorAnim.ResetTrigger("Open");
                    doorAnim.SetTrigger("Close");
                }
                inttext.SetActive(false);
                interactable = false;
            }
        }
    }
}
