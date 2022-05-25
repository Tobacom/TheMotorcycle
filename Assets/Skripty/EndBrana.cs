using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBrana : MonoBehaviour
{
    private float casS;
    private float casM;

    private void Start()
    {
        int z = PlayerPrefs.GetInt("z");
        if (!(z >= 1))
        {
            PlayerPrefs.SetFloat("EasyTimeM", 300);
            PlayerPrefs.SetFloat("EasyTimeS", 60);
            PlayerPrefs.SetFloat("MediumTimeM", 300);
            PlayerPrefs.SetFloat("MediumTimeS", 60);
            PlayerPrefs.SetFloat("HardTimeM", 300);
            PlayerPrefs.SetFloat("HardTimeS", 60);

            PlayerPrefs.SetInt("z", 1);
        }
    }

    private void Update()
    {
        casS += Time.deltaTime;

        if (casS >= 60)
        {
            casS = 0;
            casM++;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Ending");
        PlayerPrefs.SetString("aCas", $"Finished at {casM}:{Mathf.Round(casS)}");

        int diff = DiffCon.Difficulty;

        if (diff == 1)
        {
            float casME = PlayerPrefs.GetFloat("EasyTimeM");
            float casSE = PlayerPrefs.GetFloat("EasyTimeS");

            if (casM <= casME)
            {
                if (Mathf.Round(casS) < casSE)
                {
                    PlayerPrefs.SetFloat("EasyTimeM", casM);
                    PlayerPrefs.SetFloat("EasyTimeS", Mathf.Round(casS));

                    PlayerPrefs.SetString("EasyTime", $"{casM}:{Mathf.Round(casS)}");
                }
            }
        }

        if (diff == 2)
        {
            float casMM = PlayerPrefs.GetFloat("MediumTimeM");
            float casSM = PlayerPrefs.GetFloat("MediumTimeS");

            if (casM <= casMM)
            {
                if (casS < casSM)
                {
                    PlayerPrefs.SetFloat("MediumTimeM", casM);
                    PlayerPrefs.SetFloat("MediumTimeS", Mathf.Round(casS));

                    PlayerPrefs.SetString("MediumTime", $"{casM}:{Mathf.Round(casS)}");
                }
            }
        }

        if (diff == 3)
        {
            float casMH = PlayerPrefs.GetFloat("HardTimeM");
            float casSH = PlayerPrefs.GetFloat("HardTimeS");

            if (casM <= casMH)
            {
                if (casS < casSH)
                {
                    PlayerPrefs.SetFloat("HardTimeM", casM);
                    PlayerPrefs.SetFloat("HardTimeS", Mathf.Round(casS));

                    PlayerPrefs.SetString("HardTime", $"{casM}:{Mathf.Round(casS)}");
                }
            }
        }
    }
}
