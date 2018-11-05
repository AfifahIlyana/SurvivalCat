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

    private float m_timeSinceLastDamage;


    [SerializeField]
    private float m_attackCoolDown = 1f;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rigidBody = GetComponent<Rigidbody>();
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


    private void OnCollisionEnter(Collision collision)
    {
        if (m_timeSinceLastDamage > m_attackCoolDown)
        {
            m_animator.SetBool("isAttacking", true);
            m_enemyAttack.Attack(collision);
            m_timeSinceLastDamage = 0;
        }

        else
        {
              m_animator.SetBool("isAttacking", true);
        }

    }


}
