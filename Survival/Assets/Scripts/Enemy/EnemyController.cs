using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(EnemyAttack))]
[RequireComponent(typeof(EnemyData))]
[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour 
{
    
    private Animator m_animator;
    private Rigidbody m_rigidBody;

    private EnemyAttack m_enemyAttack;
    private EnemyMovement m_enemyMovement;
    private PlayerHealth m_playerHealth;
    private MyUIManager m_myUiManager;

    private float m_timeSinceLastDamage;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rigidBody = GetComponent<Rigidbody>();
        m_enemyAttack = GetComponent<EnemyAttack>();
        m_enemyMovement = GetComponent<EnemyMovement>();

        m_playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        m_myUiManager = GameObject.Find("Canvas").GetComponent<MyUIManager>();
    }

    private void Update()
    {
        m_timeSinceLastDamage += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        m_enemyMovement.Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        m_enemyMovement.CheckEdgesPlatform(other);
    }


    private void OnCollisionStay(Collision collision)
    {
        if (m_timeSinceLastDamage > 1f)
        {
            if (collision.transform.tag == "Player")
            {

                m_animator.SetBool("isAttacking", true);
                EnemyMovement.currentSpeed = 0;

                Debug.Log("inda mau kurang health si " + collision.gameObject);

                m_animator.SetBool("isAttacking", true);
                EnemyMovement.currentSpeed = 0;

                m_playerHealth.TakeDamage(1, collision.gameObject);
                m_myUiManager.UpdateHealthStatus(collision.gameObject.GetComponent<PlayerData>().m_health, false);

                m_timeSinceLastDamage = 0;
            }

            else
            {
                m_animator.SetBool("isAttacking", false);
            }

        }



    }


}
