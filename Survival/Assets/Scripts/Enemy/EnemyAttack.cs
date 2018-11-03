using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour 
{
    private PlayerHealth m_playerHealth;
    public Animator m_animator;

    private void Start()
    {
        m_playerHealth = GetComponent<PlayerHealth>();
        m_animator = GetComponent<Animator>();
    }

    public void Attack(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            // m_playerHealth.TakeDamage(1, collision.gameObject);
            m_animator.SetBool("isAttacking", true);
            EnemyMovement.currentSpeed = 0;
        }
        else
        {
            m_animator.SetBool("isAttacking", false);

        }
    }
}
