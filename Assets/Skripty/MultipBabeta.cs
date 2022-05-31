using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipBabeta : MonoBehaviour
{
    public GameObject Player;
    public GameObject BabetaDestination;
    public GameObject Babeta;

    private void Update()
    {
        Babeta.transform.position = BabetaDestination.transform.position;
        Babeta.transform.rotation = Quaternion.Euler(0, Player.transform.rotation.y, 0);

    }
}
