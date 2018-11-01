using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour 
{
    private PlayerHealth m_playerHealth;

    private void Start()
    {
        m_playerHealth = GetComponent<PlayerHealth>();
    }

    public void Attack(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            m_playerHealth.TakeDamage(1, collision.gameObject);
        }
    }
}
