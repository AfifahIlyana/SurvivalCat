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

    private float m_timeSinceLastDamage;

    private void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_myUiManager = GameObject.Find("Canvas").GetComponent<MyUIManager>();
    }

    private void Update()
    {
        m_timeSinceLastDamage += Time.deltaTime;
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
}
