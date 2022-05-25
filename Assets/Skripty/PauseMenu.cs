using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private bool isPaused;
    [SerializeField] private GameObject mys;

    private void Start()
    {
        mys.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if(isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    private void Pause()
    {
        mys.SetActive(false);
        pauseMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
        Debug.Log("Pozastaveno");
    }

    private void Resume()
    {
        mys.SetActive(true);
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        Debug.Log("Odpozastaveno");
    }

    public void ResumeButton()
    {
        isPaused = !isPaused;
        mys.SetActive(true);
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        Debug.Log("Odpozastaveno");
    }

    public void QuitToTitleConfirmButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGameConfirmButton()
    {
        Application.Quit(0);
    }
}