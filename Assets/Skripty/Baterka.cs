using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Baterka : MonoBehaviour
{
    [SerializeField] private GameObject Svitilna;
    [SerializeField] private bool sviti;
    [SerializeField] private GameObject BaterkaUseText;
    [SerializeField] private AudioSource zvuk;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            BaterkaUseText.SetActive(false);
            sviti = !sviti;

            if (sviti)
            {
                On();
            }
            else
            {
                Off();
            }
        }
    }

    private void On()
    {
        Svitilna.SetActive(true);
        zvuk.Play();
        Debug.Log("Baterka rozvícena");
    }

    private void Off()
    {
        Svitilna.SetActive(false);
        zvuk.Play();
        Debug.Log("Baterka zhasnuta");
    }
}
