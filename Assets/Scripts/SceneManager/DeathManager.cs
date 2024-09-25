using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public GameObject DeathScreen;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            DeathScreen.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
