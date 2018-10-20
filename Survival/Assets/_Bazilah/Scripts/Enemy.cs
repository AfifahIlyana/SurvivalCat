using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public CharacterController enemyController;
    public float currentSpeed;

    public int health = 100;
    public GameObject deathEffect;

    private Health playerHealth;
    private Animator animator;

    Vector3 direction = new Vector3(-1, 0, 0);


    public void Start()
    {
        animator = GetComponent<Animator>();
        enemyController = GetComponent<CharacterController>();
    }


    public void Update()
    {
        transform.Translate(direction * currentSpeed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Edge")
        {
            Debug.Log("The edge is triggered");
            ////turn around
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            direction.x *= -1;
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Die()
    {
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
