using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public int damage = 80;

    //private GameObject player;
    //private Collision m_collision;

    public static Collider m_collider;

    private void Start()
    {
        m_collider = GetComponent<Collider>();
        m_collider.enabled = false;
    }

  
    private void OnTriggerEnter(Collider collision)
    {
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

        if (collision.transform.tag == "Enemy")
        {
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

        }


    }


}
