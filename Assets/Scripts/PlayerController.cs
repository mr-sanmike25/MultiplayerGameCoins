using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    /// Date: 22/08/2024
    /// Author: Miguel Angel Garcia Elizalde y Alan Elias Carpinteyro Gastelum.
    /// Brief: C�digo del jugador y sus distintos comportamientos, como lo es el movimiento.

    public GameManager gameManager;
    [SerializeField] int m_speed;
    Rigidbody2D m_rb2D;
    Vector2 m_movement;
    Animator myAnim;

    public playerStates playerCurrentState;
    PhotonView m_pv;

    // Start is called before the first frame update
    void Start()
    {
        m_pv = GetComponent<PhotonView>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        m_rb2D = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        switch (playerCurrentState)
        {
            case playerStates.idle:
                PlayerMov();
                break;
            case playerStates.moving:
                PlayerMov();
                break;
        }
    }

    #region MovingFunctions
    /// <summary>
    /// Brief: Movimiento del jugador.
    /// </summary>
    private void PlayerMov()
    {
        if (m_pv.IsMine)
        {
            float m_movementX = Input.GetAxisRaw("Horizontal");
            float m_movementY = Input.GetAxisRaw("Vertical");

            m_movement = new Vector2(m_movementX, m_movementY).normalized;

            m_rb2D.MovePosition(m_rb2D.position + m_movement * m_speed * Time.fixedDeltaTime);

            if ((m_movementX != 0) || (m_movementY != 0))
            {
                playerCurrentState = playerStates.moving;
                myAnim.SetFloat("horMovement", m_movementX);
                myAnim.SetFloat("verMovement", m_movementY);
                myAnim.SetBool("moveBool", true);
            }
            else
            {
                playerCurrentState = playerStates.idle;
                myAnim.SetBool("moveBool", false);
            }
        }
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            //gameManager.AddCoinsToCount();
            //m_pv.RPC("addPointsInUI", RpcTarget.AllBuffered, 5);
            Destroy(collision.gameObject);
        }
    }
}

public enum playerStates
{
    idle,
    moving,
};