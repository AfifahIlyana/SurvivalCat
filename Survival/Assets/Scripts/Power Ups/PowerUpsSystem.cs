using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsSystem : MonoBehaviour 
{
    private AudioSource m_audioSource;
    private ScoreSystem m_scoreSystem;
    private MyUIManager m_myUiManager;

    [SerializeField]
    private string m_type;
    [SerializeField]
    private int m_point;
    [SerializeField]
    private AudioClip m_audioClip;

    private void Awake()
    {
        m_audioSource = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
        m_scoreSystem = GameObject.Find("Game Manager").GetComponent<ScoreSystem>();
        m_myUiManager = GameObject.Find("Canvas").GetComponent<MyUIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (m_type.ToLower() == "diamond")
            {
                if (m_scoreSystem != null)
                {
                    m_scoreSystem.AddScore(m_point, other.gameObject);
                }
            }

            if (m_type.ToLower() == "drumstick")
            {
                int playerHealth = other.GetComponent<PlayerData>().m_health;

                if (playerHealth < 3)
                {
                    other.GetComponent<PlayerHealth>().AddHealth(m_point, other.gameObject);
                    m_myUiManager.UpdateHealthStatus(playerHealth, true);
                }
            }

            if (m_audioSource != null)
            {
                m_audioSource.clip = m_audioClip;
                m_audioSource.Play();
            }

            Destroy(gameObject, 0f);

        }
    }
}
