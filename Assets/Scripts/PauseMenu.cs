using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    private bool isPause;
    private float time;

    void Start()
    {
        isPause = false;
        pauseMenu.SetActive(isPause);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        pauseMenu.SetActive(isPause);
    }

    public void Pause()
    {
        isPause = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        isPause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void ReturnToMainMenu(string scene)
    {
        Time.timeScale = 1f;
        Cursor.visible = true;
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
