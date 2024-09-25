using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public GameObject light;
    public GameObject player;
    public GameObject flashlight_table;
    public GameObject flashlight_hand;
    public bool toggle;
    public AudioSource toggleSound;

    void Start()
    {
        if(toggle == false)
        {
            light.SetActive(false);
        }
        if (toggle == true)
        {
            light.SetActive(true);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            toggle = !toggle;
            //toggleSound.Play();
            if(toggle == false)
            {
                light.SetActive(false);
            }
            if (toggle == true)
            {
                light.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
    {
        flashlight_hand.SetActive(false);
        flashlight_table.SetActive(true);
        flashlight_table.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 1.7f, player.transform.position.z);;
    }
    }
}