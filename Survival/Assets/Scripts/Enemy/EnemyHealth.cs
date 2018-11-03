using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public GameObject deathParticle;
    public Transform deathParticleSpawn;

    public void TakeDamage(int damage)
    {
        EnemyData enemy = GetComponent<EnemyData>();

        enemy.m_health -= damage;

        if (enemy.m_health <= 0)
        {
            Instantiate(deathParticle, deathParticleSpawn.position, deathParticleSpawn.rotation);
            Destroy(gameObject);
        }
    }
}
