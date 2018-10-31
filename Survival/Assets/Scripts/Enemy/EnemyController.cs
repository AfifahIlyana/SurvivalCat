using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(EnemyAttack))]
[RequireComponent(typeof(EnemyData))]
[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(Animator))]
public class EnemyController : MonoBehaviour 
{
    private EnemyMovement m_enemyMovement;
    private Animator m_animator;

    public void Start()
    {
        m_animator = GetComponent<Animator>();
        m_enemyMovement = GetComponent<EnemyMovement>();
    }

    private float m_timeSinceLastDamage;

    private void Update()
    {
        m_timeSinceLastDamage += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        m_enemyMovement.Move();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (m_timeSinceLastDamage > 1f)
            {
                other.GetComponent<PlayerHealth>().TakeDamage();

                m_timeSinceLastDamage = 0;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        m_enemyMovement.CheckEdgesPlatform(other);
    }
}
