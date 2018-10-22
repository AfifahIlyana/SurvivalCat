using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    public Joystick joystick;

    Animator m_animator;
    Player m_playerMovement;
    Rigidbody m_rigidBody;

    float m_move;
    public float m_jumpForce = 500f;


    void Start()
    {
        m_playerMovement = GetComponent<Player>();
        m_rigidBody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //Debug.Log("b"+joystick.Horizontal);

        //m_move = Utility.GetAxis().x;
        //m_move = Utility.GetAxisJoystick(joystick).x;
        //Debug.Log("b "+m_move);
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x > (Screen.width / 2))
                {
                    m_move = 1f; //moves player right
                }

                if (touch.position.x < (Screen.width / 2))
                {
                    m_move = -1f; //moves player left
                }
            }
        }

        m_playerMovement.Move(m_rigidBody, m_move, m_animator);
        m_playerMovement.Jump(m_move, m_jumpForce, m_rigidBody);


    }

    private void Update()
    {
        m_playerMovement.RotatePlayer();

        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                if (Input.GetTouch(i).tapCount == 2)
                {
                    Debug.Log("Double tap..");
                    m_playerMovement.Shoot();
                    m_animator.SetBool("isShooting", true);
                } else {
                    m_animator.SetBool("isShooting", false);
                }
            }
        }


        //if (Input.GetButtonDown("Fire1"))
        //{
        //    m_playerMovement.Shoot();
        //    m_animator.SetBool("isShooting", true);
        //} else
        //{
        //    m_animator.SetBool("isShooting", false);
        //}

      
    }

    public Vector3 GetAxisJoystick(Joystick joystick)
    {
        return new Vector3(joystick.Horizontal, 0, joystick.Vertical);
    }
}

