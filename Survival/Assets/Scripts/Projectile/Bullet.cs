using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject {

    public float speed = 30f;
    public int damage = 40;
    public Rigidbody rb;


    // Use this for initialization
    public void OnObjectSpawn()
    {

        if (GameObject.FindWithTag("Player").transform.localScale.x == 1 )
        {
            rb.velocity = -(transform.right) * speed * Time.deltaTime;
        }

        else if(GameObject.FindWithTag("Player").transform.localScale.x == -1)
        {
            rb.velocity = transform.right * speed * Time.deltaTime;
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

        if (collision.transform.tag == "Enemy")
        {
            if (enemy != null)
            {
                
                enemy.TakeDamage(damage);
            }

            gameObject.SetActive(false);
        }

    }


}
