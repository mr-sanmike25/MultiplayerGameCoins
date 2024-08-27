using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// Date: 22/08/2024
    /// Author: Miguel Angel Garcia Elizalde.
    /// Brief: Código de Game Manager (manejador de juego), en el cual se administran las diversas cosas que ocurren en partida.
    
    [SerializeField] Transform coinsParent;

    [SerializeField] int coinCount;

    void Update()
    {
        CoinManager();
    }

    private void CoinManager()
    {
        if (coinsParent.childCount == 0)
        {
            print("Coins have been collected.");
        }
    }

    public void AddCoinsToCount()
    {
        coinCount++;
    }
}
