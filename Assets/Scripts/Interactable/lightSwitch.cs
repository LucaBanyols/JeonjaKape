using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{
    public GameObject intText, light;
    public bool toggle, interactable;
    public Renderer lightBulb;
    public Material offlight, onlight;
    public AudioSource lightSwitchSound;
    public Animator switchAnim;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
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
                lightSwitchSound.Play();
                switchAnim.ResetTrigger("press");
                switchAnim.SetTrigger("press");
            }
        }

        if (toggle == false)
        {
            light.SetActive(false);
            lightBulb.material = offlight;
        }
        else
        {
            light.SetActive(true);
            lightBulb.material = onlight;
        }
    }
}
