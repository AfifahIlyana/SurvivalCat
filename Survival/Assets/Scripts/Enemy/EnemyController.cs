using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(EnemyAttack))]
[RequireComponent(typeof(EnemyData))]
[RequireComponent(typeof(EnemyMovement))]
public class EnemyController : MonoBehaviour 
{
    private float m_timeSinceLastDamage;

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
                other.GetComponent<PlayerHealth>().TakeDamage();

                m_timeSinceLastDamage = 0;
            }
        }
    }
}
