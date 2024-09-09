using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] TextMeshProUGUI m_TextMeshProUGUI;
    [SerializeField] TextMeshProUGUI m_TimerText;

    int m_currentScore;

    float remainingTime;

    PhotonView m_PV;

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
        m_PV = GetComponent<PhotonView>();
        m_TextMeshProUGUI.text = "Score: ";
        remainingTime = LevelNetworkManager.instance.RemainingTime;
        m_TimerText.text = "Time to start: " + remainingTime.ToString("0");
    }

    private void Update()
    {
        remainingTime = LevelNetworkManager.instance.RemainingTime;
        m_TimerText.text = "Time to start: " + remainingTime.ToString("0");
    }

    public void actualizarText(int p_newScore)
    {
        m_currentScore += p_newScore;
        m_TextMeshProUGUI.text = "Score: " + m_currentScore.ToString();
    }

    public void leaveCurrentRoomFromEditor()
    {
        LevelNetworkManager.instance.disconnectFromCurrentRoom();
    }

    public void addPoints()
    {
        m_PV.RPC("addPointsInUI", RpcTarget.AllBuffered, 5);
    }

    [PunRPC]
    void addPointsInUI(int p_newScore)
    {
        actualizarText(p_newScore);
    }
}
