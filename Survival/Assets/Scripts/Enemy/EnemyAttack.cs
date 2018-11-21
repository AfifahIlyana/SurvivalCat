using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour 
{
    private Animator m_animator;
    private PlayerHealth m_playerHealth;

    private MyUIManager m_myUiManager;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_playerHealth = GetComponent<PlayerHealth>();
        m_myUiManager = GameObject.Find("Canvas").GetComponent<MyUIManager>();
    }

    //public void Attack(Collision collision)
    //{
    //    if (collision.transform.tag == "Player")
    //    {
    //        m_animator.SetBool("isAttacking", true);
    //        EnemyMovement.currentSpeed = 0;
    //        m_playerHealth.TakeDamage(1, collision.gameObject);
    //        m_myUiManager.UpdateHealthStatus(collision.gameObject.GetComponent<PlayerData>().m_health, false);
    //    }

    //    else
    //    {
    //        m_animator.SetBool("isAttacking", false);
    //    }
    //}

    //public void Attack(Collider other)
    //{
    //    other.GetComponent<PlayerHealth>().TakeDamage(1, other.gameObject);
    //    m_myUiManager.UpdateHealthStatus(other.gameObject.GetComponent<PlayerData>().m_health, false);
    //}
}
