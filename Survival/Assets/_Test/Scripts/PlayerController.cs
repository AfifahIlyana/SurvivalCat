using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour 
{
    PlayerMovement m_playerMovement;
    Animator m_animator;
    Rigidbody m_rigidBody;

    float m_move;
    public float m_jumpForce;

    bool m_isGrounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;

    public LayerMask whatIsGround;

	void Start () 
    {
        m_playerMovement = GetComponent<PlayerMovement>();
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
        m_playerMovement.RotatePlayer();
    }

    Vector3 GetAxis ()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
