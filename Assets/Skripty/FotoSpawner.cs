using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FotoSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> Fotos;
    [SerializeField] int pocetFoto; //max. 5
    [SerializeField] private List<GameObject> spawnery;

    // Start is called before the first frame update
    private void Start()
    {
        int diff = DiffCon.Difficulty;
        if (diff == 5)
        {
            pocet = 5;
        }

        //Bude opakovat funkci spawner dokud nebude spawnuto nastaveny pocet fotek
        while(pocet != pocetFoto)
        {
            spawner();
            Thread.Sleep(100);
        }
    }

    List<int> deniedspwn = new List<int>();
    int pocet = 0;

    List<int> deniedfoto = new List<int>();

    public void spawner()
    {
        //vygeneruje n�hodn� ��slo od 0 do 9 (1 - 10) a zjist� jestli u� bylo pou�ito
        int spawnerint = Random.Range(0, 11);
        bool isDeniedSpwn = deniedspwn.Contains(spawnerint);

        int fotoint = Random.Range(0, 5);
        bool isDeniedFoto = deniedspwn.Contains(spawnerint);

        //pokud ano, vygeneruje se nov� ��slo
        if (isDeniedSpwn == true)
        {
            spawner();
        }

        /*pokud ne, vezme z Listu spawner (p�. n�hodn� ��slo bude 5, tak�e se ke spawnut� pou�ije spawner �. 6)
          a pou�ije pozici a rotaci spawneru ke spawnut� fotky :) */
        else if(isDeniedSpwn == false)
        {
            if(isDeniedFoto == true)
            {
                spawner();
            }

            else if(isDeniedFoto == false)
            {
                Object.Instantiate(Fotos[fotoint], spawnery[spawnerint].transform.position, spawnery[spawnerint].transform.rotation);
                deniedspwn.Add(spawnerint);
                deniedfoto.Add(fotoint);
                pocet++;
                Debug.Log($"Foto �.{fotoint + 1} bylo spawnuto na m�st� {spawnerint + 1}");
            }
        }
    }
}