using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] TextMeshProUGUI m_TextMeshProUGUI;

    int m_currentScore;

    //PhotonView m_PV;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void Start()
    {
        //m_PV = GetComponent<PhotonView>();
        m_TextMeshProUGUI.text = "Score: ";
    }

    public void actualizarText(int p_newScore)
    {
        m_currentScore += p_newScore;
        m_TextMeshProUGUI.text = "Score: " + m_currentScore.ToString();
    }

    /*[PunRPC]
    void addPointsInUI(int p_newScore)
    {
        actualizarText(p_newScore);
    }*/
}
