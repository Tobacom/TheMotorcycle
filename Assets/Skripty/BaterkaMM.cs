using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BaterkaMM : MonoBehaviour
{
    [SerializeField] private GameObject Svitilna;
    [SerializeField] private bool sviti;
    [SerializeField] private GameObject Babetka;

    private void Start()
    {
        Babetka.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
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

        int r = Random.Range(0, 10);
        if(r <= 2)
        {
            Babetka.SetActive(true);
        }
    }

    private void Off()
    {
        Svitilna.SetActive(false);
        Babetka.SetActive(false);
    }
}
