using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonConnection : MonoBehaviourPunCallbacks
{
    /// Date: 22/08/2024
    /// Author: Alan Elias Carpinteyro Gastelum.
    /// Brief: Código para conectar a cuartos y servidores de Photon.

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Se ha conectado al Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        print("Se ha entrado al Lobby Abstracto");
        PhotonNetwork.JoinOrCreateRoom("TestRoom", NewRoomInfo(), null);
    }

    public override void OnJoinedRoom()
    {
        print("Se entró al room");
        PhotonNetwork.Instantiate("Player", new Vector3(0,0,0), Quaternion.identity);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("Hubo un error al crear el room: " + message);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("Hubo un error al entrar el room: " + message);
    }

    RoomOptions NewRoomInfo()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;

        return roomOptions;
    }
}
