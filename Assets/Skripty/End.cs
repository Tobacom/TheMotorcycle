using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField] private AudioSource claping;
    [SerializeField] private Text casNow;
    [SerializeField] private Text casBest;

    // Start is called before the first frame update
    void Start()
    {
        claping.Play();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        int diff = DiffCon.Difficulty;
        casNow.text = PlayerPrefs.GetString("aCas");

        if (diff == 1) 
        {
            casBest.text = $"Best {PlayerPrefs.GetString("EasyTime")}";
        }

        else if (diff == 2)
        {
            casBest.text = $"Best {PlayerPrefs.GetString("MediumTime")}";
        }

        else if (diff == 3)
        {
            casBest.text = $"Best {PlayerPrefs.GetString("HardTime")}";
        }

        else if (diff == 5)
        {
            casNow.text = ":)";
            casBest.text = "Now go try it for real";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Ending", claping.clip.length);
    }

    private void Ending()
    {
        SceneManager.LoadScene("Menu");
    }
}
