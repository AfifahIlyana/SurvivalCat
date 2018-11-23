using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    
    public GameObject deathParticle;
    public Transform deathParticleSpawn;
    
    public void TakeDamage(int damage)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerController audio = player.GetComponent<PlayerController>();

        EnemyData enemy = GetComponent<EnemyData>();

        audio.EnemyHitSound();

        enemy.m_health -= damage;

        if (enemy.m_health <= 0)
        {
            ScoreSystem score = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreSystem>();
            Animator plusScore = GameObject.Find("+50").GetComponent<Animator>();
            
            audio.EnemyDownSound();

            score.AddScore(50, player);
            plusScore.SetTrigger("AddScore");

            Instantiate(deathParticle, deathParticleSpawn.position, deathParticleSpawn.rotation);
            Destroy(gameObject);
        }
    }
}
