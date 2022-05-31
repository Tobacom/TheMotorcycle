using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectManager : MonoBehaviourPunCallbacks
{
    public InputField nicknameInput;
    public Text btnText;

    public void onClickConnectBtn()
    {
        if (nicknameInput.text.Length >= 1)
        {
            PhotonNetwork.NickName = nicknameInput.text;
            btnText.text = "Connecting...";
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");
        PhotonNetwork.JoinLobby();
    }
}
