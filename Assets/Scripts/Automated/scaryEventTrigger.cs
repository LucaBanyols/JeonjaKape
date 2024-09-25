using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaryEventTrigger : MonoBehaviour
{
    public GameObject scare;
    public Collider collision;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scare.SetActive(true);
            collision.enabled = false;
        }
    }
}