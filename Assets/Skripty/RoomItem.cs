using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public Text roomName;
    LobbyManager manager;

    private void Start()
    {
        manager = FindObjectOfType<LobbyManager>();

    }

    public void setRoomName(string _roomName)
    {
        roomName.text = _roomName;
    }

    public void onClickRoomItem()
    {
        manager.JoinRoom(roomName.text);
    }
}
