using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MMTlacitka : MonoBehaviour
{
    [SerializeField] private GameObject casy;
    [SerializeField] private Text Easy;
    [SerializeField] private Text Medium;
    [SerializeField] private Text Hard;
    [SerializeField] private GameObject TestModeMenu;
    [SerializeField] private AudioSource blip;
    [SerializeField] private GameObject single;

    private void Update()
    {
        if (single.active == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    TestModeMenu.SetActive(true);
                    blip.Play();
                }
            }
        }
    }

    private void Start()
    {
        casy.SetActive(true);

        Easy.text = PlayerPrefs.GetString("EasyTime");
        Medium.text = PlayerPrefs.GetString("MediumTime");
        Hard.text = PlayerPrefs.GetString("HardTime");

        casy.SetActive(false);
    }

    public void resetAll()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString("EasyTime", "");
        PlayerPrefs.SetString("MediumTime", "");
        PlayerPrefs.SetString("HardTime", "");
        Debug.Log("Progress reseted");
    }

    public void Quit()
    {
        Application.Quit(0);
    }
}
