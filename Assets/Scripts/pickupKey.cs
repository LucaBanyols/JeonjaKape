using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupKey : MonoBehaviour
{
    public GameObject inttext, Key_table, Key_hand;
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
                Key_hand.SetActive(true);
                Key_table.SetActive(false);
            }
        }
    }
}
