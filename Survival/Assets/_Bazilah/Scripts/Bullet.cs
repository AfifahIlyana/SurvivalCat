using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Player player;
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }


    void OnTriggerEnter (Collider hitInfo)
    {
        Health enemyHealth = hitInfo.GetComponent<Health>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamageEnemy(damage);
        }

        Destroy(gameObject);
    }


}
