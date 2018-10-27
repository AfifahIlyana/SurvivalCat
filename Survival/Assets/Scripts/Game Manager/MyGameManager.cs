using UnityEngine;

public class MyGameManager : MonoBehaviour 
{
    private GameObject m_player;
    private ScoreSystem m_scoreSystem;

    [HideInInspector]
    public int m_lastHeight;

	void Start () 
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_scoreSystem = GetComponent<ScoreSystem>();

        m_scoreSystem.ResetScore(m_player);
	}
	
	void Update () 
    {
        if (m_player != null)
        {
            m_scoreSystem.HeightScore(m_lastHeight, m_player);
        }
	}
}
