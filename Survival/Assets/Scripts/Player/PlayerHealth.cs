﻿using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
    public void TakeDamage (int reduceHealth, GameObject player)
    {
        player.GetComponent<PlayerData>().m_health -= reduceHealth;


        if (player.GetComponent<PlayerData>().m_health <= 0)
        {
            GameOver gameover = GameObject.Find("Canvas").GetComponent<GameOver>();
            gameover.TriggerGameOver();
        }
    }

    public void AddHealth (int addHealth, GameObject player)
    {
        player.GetComponent<PlayerData>().m_health += addHealth;
    }

    public void ResetHealth (PlayerData playerHealth)
    {
        playerHealth.m_health = 3;
    }
}
