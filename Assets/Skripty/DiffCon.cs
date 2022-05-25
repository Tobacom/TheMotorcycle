using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiffCon : MonoBehaviour
{
    public static int Difficulty
    {
        get => PlayerPrefs.GetInt("diff");
        set => PlayerPrefs.SetInt("diff", value);
    }

    public void PlayE()
    {
        SceneManager.LoadScene("Hra");
        Difficulty = 1;
    }

    public void PlayM()
    {
        SceneManager.LoadScene("Hra");
        Difficulty = 2;
    }

    public void PlayH()
    {
        SceneManager.LoadScene("Hra");
        Difficulty = 3;
    }

    public void PlayTM()
    {
        SceneManager.LoadScene("Hra");
        Difficulty = 5;
    }
}