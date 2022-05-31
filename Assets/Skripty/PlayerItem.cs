using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerItem : MonoBehaviourPunCallbacks
{
    public Text playerNick;
    public Image bgImage;
    public Color highlightColor;
    public GameObject leftArrowBtn;
    public GameObject rightArrowBtn;

    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    public Image playerAvatar;
    public Sprite[] avatars;

    Player player;

    private void Start()
    {
        bgImage = GetComponent<Image>();
    }

    public void SetPlayerNick(Player _player)
    {
        playerNick.text = _player.NickName;
        player = _player;
        UpdatePlayerItem(player);
    }

    public void ApplyLocalChanges()
    {
        bgImage.color = highlightColor;
        leftArrowBtn.SetActive(true);
        rightArrowBtn.SetActive(true);
    }

    public void OnClickLeft()
    {
        if ((int)playerProperties["avatar"] == avatars.Length - 1)
        {
            playerProperties["avatar"] = avatars.Length - 1;
        } else
        {
            playerProperties["avatar"] = (int)playerProperties["avatar"] - 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public void OnClickRight()
    {
        if ((int)playerProperties["avatar"] == 0)
        {
            playerProperties["avatar"] = 0;
        }
        else
        {
            playerProperties["avatar"] = (int)playerProperties["avatar"] + 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (player == targetPlayer)
        {
            UpdatePlayerItem(targetPlayer);
        }
    }
    void UpdatePlayerItem(Player player)
    {
        if (player.CustomProperties.ContainsKey("avatar"))
        {
            playerAvatar.sprite = avatars[(int)player.CustomProperties["avatar"]];
            playerProperties["avatar"] = (int)playerProperties["avatar"];
        } else
        {
            playerProperties["avatar"] = 0;
        }
    }
}
