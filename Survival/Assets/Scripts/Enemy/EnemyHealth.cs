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
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            ScoreSystem score = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreSystem>();
            Animator plusScore = GameObject.Find("+50").GetComponent<Animator>();

            PlayerController audioDied = player.GetComponent<PlayerController>();
            audioDied.EnemyDownSound();

            score.AddScore(50, player);
            plusScore.SetTrigger("AddScore");

            Instantiate(deathParticle, deathParticleSpawn.position, deathParticleSpawn.rotation);
            Destroy(gameObject);
        }
    }
}
