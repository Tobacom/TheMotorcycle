using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.UI;
using UnityEngine;

public class BranaControllerEnd : MonoBehaviour
{
    private int pocetdootevreni = 0;
    [SerializeField] private GameObject Brana;
    [SerializeField] private Text FotoCounter;
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private AudioSource branaOpen;
    [SerializeField] private GameObject branaAlertText;
    BabetakNavMesh babetak;

    public void Pocitani()
    {
        pocetdootevreni++;
        collectSound.Play();
        FotoCounter.text = $"{pocetdootevreni}/5";
        Debug.Log($"Fotky {pocetdootevreni}/5");

        if (pocetdootevreni >= 5)
        {
            Brana.transform.Translate(Brana.transform.position.x, Brana.transform.position.y - 5, Brana.transform.position.z);
            Debug.Log("Brána otevøena");
            branaOpen.Play();
            branaAlertText.SetActive(true);

            babetak = GameObject.FindGameObjectWithTag("Babeta").GetComponent<BabetakNavMesh>();
            babetak.Ending();
        }
    }
}
