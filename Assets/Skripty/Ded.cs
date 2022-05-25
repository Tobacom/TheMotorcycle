using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ded : MonoBehaviour
{
    [SerializeField] private AudioSource JumpscareAudio;
    [SerializeField] private GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        JumpscareAudio.Play();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        Invoke("Buttons", 2);
    }

    public void Buttons()
    {
        UI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Hra");
    }

    public void ReturnToMM()
    {
        SceneManager.LoadScene("Menu");
    }
}
