using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    public float gravityScale = 1.0f;
    public Joystick joystick;
    Animator m_animator;
    Player m_playerMovement;
    Rigidbody m_rigidBody;

    float m_move;
    public float m_jumpForce = 500f;

    bool m_isGrounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;

    public LayerMask whatIsGround;

    void Start()
    {
        m_playerMovement = GetComponent<Player>();
        m_rigidBody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //grounded = Physics.OverlapSphere(groundCheck.position, groundRadius, whatIsGround);
        //anim.SetBool("ground", grounded);
        //
        //anim.SetFloat("vSpeed", rb.velocity.y);

        m_move = GetAxis().x;
        m_playerMovement.Move(m_rigidBody, m_move, m_animator);
        m_playerMovement.Jump(m_move, m_jumpForce, m_rigidBody);
    }

    private void Update()
    {
        transform.Translate(Vector3.down * gravityScale * Time.deltaTime);
        m_playerMovement.RotatePlayer();

        if (Input.GetButtonDown("Fire1"))
        {
            m_playerMovement.Shoot();
            m_animator.SetBool("isShooting", true);
        } else
        {
            m_animator.SetBool("isShooting", false);
        }

      
    }

    Vector3 GetAxis()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //return new Vector3(joystick.Horizontal, 0, joystick.Vertical);
    }
}

