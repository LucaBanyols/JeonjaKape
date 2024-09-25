using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void ExitWindow() {
        Debug.Log("Application stopped successfully");
        Application.Quit();
    }
}
