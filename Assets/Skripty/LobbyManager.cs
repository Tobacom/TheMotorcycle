using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField createRoomInput;
    public InputField joinRoomInput;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomName;

    public List<PlayerItem> playerItemsList = new List<PlayerItem>();
    public PlayerItem playerItemPrefab;
    public Transform playerItemParent;

    public GameObject launchGameBtn;

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            launchGameBtn.SetActive(true);
        } else
        {
            launchGameBtn.SetActive(false);
        }
    }

    public void OnClickLaunchGameBtn()
    {
        PhotonNetwork.LoadLevel("HraM");
    }

    public void OncClickCreateRoom()
    {
        if (createRoomInput.text.Length > 0)
        {
            PhotonNetwork.CreateRoom(createRoomInput.text, new RoomOptions() { MaxPlayers = 4, BroadcastPropsChangeToAll = true});
        }
    }

    public void OncClickJoinRoom()
    {
        if (joinRoomInput.text.Length > 0)
        {
            PhotonNetwork.JoinRoom(joinRoomInput.text);
        }
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void onClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    void UpdatePlayerList()
    {
        foreach (PlayerItem item in playerItemsList)
        {
            Destroy(item.gameObject);
        }
        playerItemsList.Clear();

        if(PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem newPlayerItem =  Instantiate(playerItemPrefab, playerItemParent);
            newPlayerItem.SetPlayerNick(player.Value);

            if (player.Value == PhotonNetwork.LocalPlayer)
            {
                newPlayerItem.ApplyLocalChanges();
            }

            playerItemsList.Add(newPlayerItem);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

    public void LeaveMultiplayer()
    {
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        SceneManager.LoadScene("Menu");
        PhotonNetwork.LeaveLobby();
    }
}
