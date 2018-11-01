using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(EnemyAttack))]
[RequireComponent(typeof(EnemyData))]
[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour 
{
    private Rigidbody m_rigidBody;
    private MyUIManager m_myUiManager;
    private EnemyAttack m_enemyAttack;
    private EnemyMovement m_enemyMovement;

    private float m_timeSinceLastDamage;

    private void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_myUiManager = GameObject.Find("Canvas").GetComponent<MyUIManager>();
        m_enemyAttack = GetComponent<EnemyAttack>();
        m_enemyMovement = GetComponent<EnemyMovement>();
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

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (m_timeSinceLastDamage > 1f)
            {
                other.GetComponent<PlayerHealth>().TakeDamage(1, other.gameObject);
                m_myUiManager.UpdateHealthStatus(other.gameObject.GetComponent<PlayerData>().m_health, false);

                m_timeSinceLastDamage = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_enemyAttack.Attack(collision);
    }
}
