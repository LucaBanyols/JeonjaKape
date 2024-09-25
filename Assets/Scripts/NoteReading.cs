using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteReading : MonoBehaviour
{
    public GameObject note_table;
    public GameObject note_hand;
    public bool toggle;
    public AudioSource toggleSound;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            note_hand.SetActive(false);
            note_table.SetActive(true);
        }
    }
}