using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foto : MonoBehaviour
{
    [SerializeField] private GameObject Fotka;
    [SerializeField] private float speed;
    BranaControllerEnd endBrana;

    // Update is called once per frame
    void Update()
    {
        Fotka.transform.Rotate(0, Time.deltaTime * speed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        endBrana = GameObject.FindGameObjectWithTag("BranaController").GetComponent<BranaControllerEnd>();
        endBrana.Pocitani();
        Debug.Log($"Fotka è.{Fotka} byla collectnuta");
        Fotka.SetActive(false);
    }
}
