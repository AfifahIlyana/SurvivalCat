using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsSystem : MonoBehaviour 
{
    private AudioSource m_audioSource;
    private ScoreSystem m_scoreSystem;
    private MyUIManager m_myUiManager;
    private Animator m_plusScore_10;
    private Animator m_plusScore_30;

    [SerializeField]
    private string m_type;
    [SerializeField]
    private int m_point;
    [SerializeField]
    private AudioClip m_audioClip;

    private void Awake()
    {
        m_audioSource = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
        m_scoreSystem = GameObject.Find("Gameplay Manager").GetComponent<ScoreSystem>();
        m_myUiManager = GameObject.Find("Canvas").GetComponent<MyUIManager>();
        m_plusScore_10 = GameObject.Find("+10").GetComponent<Animator>();
        m_plusScore_30 = GameObject.Find("+30").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            if (m_type.ToLower() == "diamond") {
                if (m_scoreSystem != null) {
                    m_scoreSystem.AddScore(m_point, other.gameObject);
                    m_plusScore_10.SetTrigger("AddScore");
                }
            }

            if (m_type.ToLower() == "specialdiamond") {
                if (m_scoreSystem != null) {
                    m_scoreSystem.AddScore(m_point, other.gameObject);
                    m_plusScore_30.SetTrigger("AddScore");
                }
            }

            if (m_type.ToLower() == "drumstick") {
                int playerHealth = other.GetComponent<PlayerData>().m_health;

                if (playerHealth < 3) {
                    other.GetComponent<PlayerHealth>().AddHealth(m_point, other.gameObject);
                    m_myUiManager.UpdateHealthStatus(playerHealth, true);
                }
            }

            if (m_type.ToLower() == "potion")
            {
                StartCoroutine("ActivatePotion");
            }

            if (m_audioSource != null) {
                m_audioSource.clip = m_audioClip;
                m_audioSource.Play();
            }

            Destroy(gameObject, 0f);
        }
        

    }

    IEnumerator ActivatePotion ()
    {
        PlayerData.isPotionActivated = true;
        yield return new WaitForSeconds(10f);
        PlayerData.isPotionActivated = false;
    }
}
