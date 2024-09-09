using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintCoinsCollected : MonoBehaviour
{
    PhotonView m_PV;

    private void Start()
    {
        m_PV = GetComponent<PhotonView>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            m_PV.RPC("PrintNameWhenCollectingCoinsRPC", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    void PrintNameWhenCollectingCoinsRPC()
    {
        print(m_PV.Owner.NickName + " ha recogido una moneda.");
    }
}
