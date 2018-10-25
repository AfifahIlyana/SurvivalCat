using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    
    private int currentHeart = 3;
    private GameObject[] heart;
    
    private void Start() {
        heart = GameObject.FindGameObjectsWithTag("Heart");
        
    }

    private void UpdateHeart() {
        for (int i = 0; i < heart.Length; i++) {
            Debug.Log("heart " + heart[i]);
            if (i > currentHeart - 1) {
                heart[i].SetActive(false);

            } else {
                heart[i].SetActive(true);

            }
        }
    }

    public void Heal() {
        currentHeart++;

        if (currentHeart > 3) {
            currentHeart = 3;
        }

        UpdateHeart();

    }

    public void TakeDamage() {
        currentHeart--;
        KnockBack();

        if (currentHeart <= 0) {
            currentHeart = 0;

            // trigger gameover animation

            GameOver gameover = GameObject.FindGameObjectWithTag("GameOverTrigger").GetComponent<GameOver>();
            gameover.TriggerGameOver();

        }

        UpdateHeart();
        
    }

    public void TakeDamageEnemy(int damage)
    {
        Enemy.health -= damage;

        if (Enemy.health <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void KnockBack() {

    }

}
