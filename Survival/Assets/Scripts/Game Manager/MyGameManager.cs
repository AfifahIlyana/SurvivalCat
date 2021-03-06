﻿using UnityEngine;

public class MyGameManager : MonoBehaviour 
{
    private GameObject m_player;
    private ScoreSystem m_scoreSystem;
    private MyUIManager m_myUiManager;

    
    [HideInInspector]
    public int m_lastHeight;


    void Start () 
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_scoreSystem = GetComponent<ScoreSystem>();
        m_myUiManager = GameObject.Find("Canvas").GetComponent<MyUIManager>();

        m_scoreSystem.ResetScore(m_player);
        m_lastHeight = 0;
	}
	
	void Update () 
    {
        if (m_player != null)
        {
            m_lastHeight = m_scoreSystem.HeightScore(m_lastHeight, m_player);
            m_myUiManager.UpdateScoreStatus(m_player);
        }
	}

}
