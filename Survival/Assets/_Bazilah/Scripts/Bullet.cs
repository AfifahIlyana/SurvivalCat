﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private PlayerMovement player;
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody rb;

    // Use this for initialization
    void Update()
    {
        var localVelocity = transform.InverseTransformDirection(rb.velocity);
        localVelocity = transform.right * speed;
        rb.velocity = transform.TransformDirection(localVelocity);

        //if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().m_isFacingRight)
        //{
        //    localVelocity = transform.right * speed;
        //    rb.velocity = transform.TransformDirection(localVelocity);
        //}

        //else
        //{
        //    localVelocity = -(transform.right) * speed;
        //    rb.velocity = transform.TransformDirection(localVelocity);
        //}

    }

    //void OnTriggerEnter (Collider hitInfo)
    //{
    //    Enemy enemy = hitInfo.GetComponent<Enemy>();

    //    if (enemy != null)
    //    {
    //        enemy.TakeDamage(damage);
    //    }

    //    Destroy(gameObject);
    //}


}
