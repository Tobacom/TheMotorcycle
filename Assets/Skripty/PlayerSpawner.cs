using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject babetaPrefab;
    public Transform[] spawns;

    private void Start()
    {
        int rspawn = Random.Range(0, 4);
        Transform spawnpoint = spawns[rspawn];

        int impasta = Random.Range(1, PhotonNetwork.CountOfPlayers + 1);
        PhotonNetwork.CurrentRoom.GetPlayer(impasta);
        PhotonNetwork.Instantiate("babetaPrefab", spawns[rspawn].transform.position, Quaternion.identity);
    }
}
