using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour 
{
    private GameObject m_player;
    private PlatformSpawner m_platformSpawner;

    [SerializeField]
    private int platformHolderNumber;

    void Start () 
    {
        m_player = GameObject.FindWithTag("Player");
        m_platformSpawner = GetComponent<PlatformSpawner>();
	}
	
	void Update () 
    {
        if (Utility.objectMovedUp == gameObject.transform.name)
        {
            if (m_platformSpawner != null)
            {
                m_platformSpawner.ReshufflePlatformPosition(platformHolderNumber);
            }
        }
    }
}
