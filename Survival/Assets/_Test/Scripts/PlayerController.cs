﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour 
{
    PlayerMovement m_playerMovement;
    Animator m_animator;

    public float maxSpeed = 10f;
    bool facingRight = true;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;

    public LayerMask whatIsGround;

    public float jumpForce = 700f;

	void Start () 
    {
        m_playerMovement = GetComponent<PlayerMovement>();
        m_animator = GetComponent<Animator>();
	}

    void FixedUpdate() 
    {

        Rigidbody rb = GetComponent<Rigidbody>();

        //grounded = Physics.OverlapSphere(groundCheck.position, groundRadius, whatIsGround);
        //anim.SetBool("ground", grounded);

        //anim.SetFloat("vSpeed", rb.velocity.y);

        float move = Input.GetAxis("Horizontal");

        m_animator.SetFloat("speed", Mathf.Abs(move));
        
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
        
        if (Input.GetButtonDown("Jump")) 
        {
            //anim.SetBool("ground", false);
            rb.AddForce(new Vector2(move, jumpForce));
        }

    }

    private void Update()
    {
        m_playerMovement.RotatePlayer();
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
}
