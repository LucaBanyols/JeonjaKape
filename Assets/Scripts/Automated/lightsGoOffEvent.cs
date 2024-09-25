using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsGoOffEvent : MonoBehaviour
{
    public GameObject light;
    public Collider collision;
    public AudioSource lightExplosionSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            light.SetActive(false);
            collision.enabled = false;
            lightExplosionSound.Play();
        }
    }
}