using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    /// Date: 22/08/2024
    /// Author: Miguel Angel Garcia Elizalde.
    /// Brief: Código de Game Manager (manejador de juego), en el cual se administran las diversas cosas que ocurren en partida.
    
    public static GameManager instance;

    [SerializeField] Transform coinsParent;

    [SerializeField] int coinCount;

    string playerWhoGotLastCoin;

    PhotonView m_PV;

    public string PlayerWhoGotLastCoin { get => playerWhoGotLastCoin; set => playerWhoGotLastCoin = value; }

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

    private void Start()
    {
        m_PV = GetComponent<PhotonView>();
    }

    void Update()
    {
        playerNameLastCoin(PlayerWhoGotLastCoin);
        CoinManager();

        if(coinsParent.childCount == 0)
        {
            UIManager.Instance.getLastCoinFunction(PlayerWhoGotLastCoin);
        }
    }

    private void CoinManager()
    {
        if (coinsParent.childCount == 0)
        {
            print("Coins have been collected by " + PlayerWhoGotLastCoin);
        }
    }

    public void playerNameLastCoin(string p_playerName)
    {
        PlayerWhoGotLastCoin = p_playerName;
    }

    public void AddCoinsToCount()
    {
        coinCount++;
    }
}
