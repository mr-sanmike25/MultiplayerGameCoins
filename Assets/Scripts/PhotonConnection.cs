using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class PhotonConnection : MonoBehaviourPunCallbacks
{
    /// Date: 22/08/2024
    /// Author: Alan Elias Carpinteyro Gastelum.
    /// Brief: C�digo para conectar a cuartos y servidores de Photon.

    [SerializeField] TMP_InputField m_newInputField;
    [SerializeField] TMP_InputField m_newNickname;
    [SerializeField] TextMeshProUGUI m_joinRoomFailedTextMeshProUGUI;
    [SerializeField] TextMeshProUGUI m_createRoomFailedTextMeshProUGUI;
    [SerializeField] TextMeshProUGUI m_nicknameFailedTextMeshProUGUI;

    [SerializeField] string nickname;
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

        PhotonNetwork.NickName = nickname;
        //PhotonNetwork.JoinOrCreateRoom("TestRoom", NewRoomInfo(), null);
    }

    public override void OnJoinedRoom()
    {
        print("Se entr� al room");
        //PhotonNetwork.Instantiate("Player", new Vector3(0,0,0), Quaternion.identity);
        PhotonNetwork.LoadLevel("Gameplay");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("Hubo un error al crear el room: " + message);
        m_createRoomFailedTextMeshProUGUI.gameObject.SetActive(true);
        m_createRoomFailedTextMeshProUGUI.text = "Hubo un error al crear el room: " + m_newInputField.text;
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("Hubo un error al entrar el room: " + message);
        m_joinRoomFailedTextMeshProUGUI.gameObject.SetActive(true);
        m_joinRoomFailedTextMeshProUGUI.text = "Hubo un error al entrar al room: " + m_newInputField.text;
    }

    RoomOptions NewRoomInfo()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 6;
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;

        return roomOptions;
    }

    public void joinRoom()
    {
        if (nickname == "")
        {
            m_nicknameFailedTextMeshProUGUI.gameObject.SetActive(true);
            m_nicknameFailedTextMeshProUGUI.text = "Introduce un nombre, no lo dejes en blanco.";
            print("Necesita un nombre.");
            return;
        }
        else
        {
            nickname = m_newNickname.text;
        }

        if (m_newInputField.text == "")
        {
            m_joinRoomFailedTextMeshProUGUI.text = "Este espacio no lo puedes dejar en blanco.";
            m_joinRoomFailedTextMeshProUGUI.gameObject.SetActive(true);
        }
        else
        {
            PhotonNetwork.JoinRoom(m_newInputField.text);
        }
    }

    public void createRoom()
    {
        if (nickname == "")
        {
            m_nicknameFailedTextMeshProUGUI.gameObject.SetActive(true);
            m_nicknameFailedTextMeshProUGUI.text = "Introduce un nombre, no lo dejes en blanco.";
            print("Necesita un nombre.");
            return;
        }
        else
        {
            nickname = m_newNickname.text;
        }

        if (m_newInputField.text == "")
        {
            m_createRoomFailedTextMeshProUGUI.text = "Este espacio no lo puedes dejar en blanco.";
            m_createRoomFailedTextMeshProUGUI.gameObject.SetActive(true);
        }
        else
        {
            PhotonNetwork.CreateRoom(m_newInputField.text, NewRoomInfo(), null);
        }
    }

    public void SaveNickname()
    {
        if (m_newNickname.text != "")
        {
            nickname = m_newNickname.text;
            PhotonNetwork.NickName = nickname;
        }
    }
}
