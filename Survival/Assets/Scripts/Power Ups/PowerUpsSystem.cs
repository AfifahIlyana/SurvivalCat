﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsSystem : MonoBehaviour 
{
    private AudioSource m_audioSource;
    private ScoreSystem m_scoreSystem;

    [SerializeField]
    private string m_type;
    [SerializeField]
    private int m_point;
    [SerializeField]
    AudioClip m_audioClip;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_scoreSystem = GameObject.Find("MyGameManager").GetComponent<ScoreSystem>();
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
                other.GetComponent<PlayerHealth>().AddHealth();
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
