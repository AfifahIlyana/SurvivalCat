using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerInput : MonoBehaviour
{
    public Joystick joystick;

    Animator m_animator;
    Player m_playerMovement;
    Rigidbody m_rigidBody;

    float m_move;
    public static float m_jumpForce = 400f;

    void Start()
    {
        m_playerMovement = GetComponent<Player>();
        m_rigidBody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {

        //m_move = Utility.GetAxisJoystick(joystick).x;
        //m_move = Utility.GetAxis().x;
        m_playerMovement.Move(m_rigidBody, m_move, m_animator);


    }

    private void Update()
    {
        m_playerMovement.RotatePlayer();
        //PlayerTouchMovement();
    }


    public void PlayerMovement(float horizontal)
    {
        m_move = horizontal;

    }

    public void Jump()
    {
        m_playerMovement.Jump(m_move, m_jumpForce, m_rigidBody);
    }

    //void PlayerTouchMovement()
    //{

    //    for (int i = 0; i < Input.touchCount; i++)
    //    {
    //        Touch touch = Input.GetTouch(i);

    //        if (touch.phase == TouchPhase.Stationary)
    //        {

    //            if (touch.position.x > (Screen.width / 2))
    //            {
                    
    //                m_move = 1f; //moves player right
                   
    //            }

    //            if (touch.position.x < (Screen.width / 2))
    //            {
    //                m_move = -1f; //moves player left
    //            }

    //        }

    //        if (touch.phase == TouchPhase.Ended)
    //        {
    //            m_move = 0f;

    //        }


    //    }
    //}

}

