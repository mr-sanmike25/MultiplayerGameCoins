using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LevelNetworkManager : MonoBehaviourPunCallbacks
{
    public static LevelNetworkManager instance;
    PhotonView m_PV;
    [SerializeField] private bool playerCanMove;
    [SerializeField] float remainingTime = 3.0f;

    public bool PlayerCanMove { get => playerCanMove; set => playerCanMove = value; }
    public float RemainingTime { get => remainingTime; set => remainingTime = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            m_PV = GetComponent<PhotonView>();
        }
        else
        {
            Destroy(instance);
        }
    }

    private void Update()
    {
        if(PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            Timer();

            if ((RemainingTime <= 0.0f) && (!PlayerCanMove))
            {
                m_PV.RPC("ActivateMovements", RpcTarget.AllBuffered);
            }
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
        print("Entró nuevo player: " + newPlayer.NickName);
    }

    [PunRPC]
    void ActivateMovements()
    {
        print("Ya entró el segundo player y ya se pueden mover");
        PlayerCanMove = true;
    }

    void Timer()
    {
        if(remainingTime >= 0.0f)
        {
            RemainingTime -= Time.deltaTime;
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        print("Salió el player: " + otherPlayer.NickName);
    }
}
