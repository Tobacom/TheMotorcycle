using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class PauseMenuM : MonoBehaviourPunCallbacks
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
    }

    private void Resume()
    {
        mys.SetActive(true);
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ResumeButton()
    {
        isPaused = !isPaused;
        mys.SetActive(true);
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitToTitleConfirmButton()
    {
        PhotonNetwork.LeaveLobby();
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        SceneManager.LoadScene("Menu");
    }
}