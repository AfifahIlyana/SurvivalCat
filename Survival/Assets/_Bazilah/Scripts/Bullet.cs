using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject {

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody rb;

    // Use this for initialization
    public void OnObjectSpawn()
    {
        var localVelocity = transform.InverseTransformDirection(rb.velocity);
      
        if (GameObject.FindWithTag("Player").transform.localScale.x == 1 )
        {
            localVelocity = -(transform.right) * speed * Time.deltaTime;
        }

        else if(GameObject.FindWithTag("Player").transform.localScale.x == -1)
        {
            localVelocity = transform.right * speed * Time.deltaTime;

        }

        rb.velocity = transform.TransformDirection(localVelocity);
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
