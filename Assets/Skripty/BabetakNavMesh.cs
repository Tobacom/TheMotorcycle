using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BabetakNavMesh : MonoBehaviour
{
    public NavMeshAgent Babetak;
    public GameObject Player;
    public List<GameObject> DefaultDestinations;
    [SerializeField] private AudioSource VitrScary;
    [SerializeField] private AudioSource heartbeat;
    [SerializeField] private GameObject predBrana;

    public GameObject Babeta;
    public GameObject TestMode;

    private float casNaOnExit = 15;

    float BabD = 0;
    float PlD = 0;
    float Sum;
    float SpotDistance;
    int DD;


    private void Start()
    {
        DD = Random.Range(0, 5);
        Babetak.SetDestination(DefaultDestinations[DD].transform.position);
        Debug.Log($"Babetak jede na DD {DD + 1}");

        RenderSettings.fogColor = Color.black;
        Babetak.updateRotation = true;

        int diff = DiffCon.Difficulty;

        if (diff == 1)
        {
            Easy();
        }

        else if (diff == 2)
        {
            Medium();
        }

        else if (diff == 3)
        {
            Hard();
        }

        else if (diff == 5)
        {
            TrainMode();
        }
    }

    private void Update()
    {
        casNaOnExit -= Time.deltaTime;

        BabD = Babetak.transform.position.x + Babetak.transform.position.y + Babetak.transform.position.z;
        PlD = Player.transform.position.x + Player.transform.position.y + Player.transform.position.z;
        Sum = BabD - PlD;

        if (Sum < SpotDistance && Sum > -SpotDistance)
        {
            Babetak.SetDestination(Player.transform.position);

            var dir = Quaternion.LookRotation(Player.transform.position - transform.position).eulerAngles;
            transform.rotation = Quaternion.Euler(0, dir.y - 90, 0);

            casNaOnExit = 1;
        }

        else
        {
            if (casNaOnExit < 0)
            {
                DD = Random.Range(0, 5);
                Babetak.SetDestination(DefaultDestinations[DD].transform.position);
                Debug.Log($"Babetak nyní jede na DD {DD + 1}");
                casNaOnExit = 15;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("U ded XD");
        SceneManager.LoadScene("Ded");
    }

    public void Ending()
    {
        Babetak.SetDestination(predBrana.transform.position);
    }

    public void Easy()
    {
        Babetak.speed = 1;
        SpotDistance = 8;
        Debug.Log("Difficulty: Easy");
        RenderSettings.fogDensity = 0.50f;
    }

    public void Medium()
    {
        Babetak.speed = 3;
        SpotDistance = 16;
        Debug.Log("Difficulty: Medium");
        RenderSettings.fogDensity = 0.75f;
    }

    public void Hard()
    {
        Babetak.speed = 5;
        SpotDistance = 1000;
        Debug.Log("Difficulty: Hard");
        RenderSettings.fogDensity = 1;
    }

    public void TrainMode()
    {
        Debug.Log("Difficulty: /TrainMode");
        RenderSettings.fogDensity = 0.01f;
        RenderSettings.fogColor = Color.gray;
        VitrScary.Stop();
        TestMode.SetActive(true);
        Babeta.SetActive(false);
    }
}