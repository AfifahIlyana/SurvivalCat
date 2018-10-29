using UnityEngine;

public class MyGameManager : MonoBehaviour 
{
    private GameObject m_player;
    private ScoreSystem m_scoreSystem;

    //[HideInInspector]
    public int m_lastHeight;

    private void Awake()
    {
        m_player = GameObject.Find("Cat");
        m_scoreSystem = GetComponent<ScoreSystem>();
    }
    void Start () 
    {
        m_scoreSystem.ResetScore(m_player);
        m_lastHeight = 0;
	}
	
	void Update () 
    {
        if (m_player != null)
        {
            m_lastHeight = m_scoreSystem.HeightScore(m_lastHeight, m_player);
        }
	}
}
