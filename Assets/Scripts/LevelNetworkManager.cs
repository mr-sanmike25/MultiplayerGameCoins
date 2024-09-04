using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LevelNetworkManager : MonoBehaviourPunCallbacks
{
    public static LevelNetworkManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    public void disconnectFromCurrentRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Menu");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
       base.OnDisconnected(cause);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print("Entr� nuevo player: " + newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        print("Sali� el player: " + otherPlayer.NickName);
    }
}
