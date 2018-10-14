using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour 
{

    public Transform m_player;

	void Start () 
    {
        transform.rotation = m_player.transform.rotation;
		
	}
	
	void Update () 
    {
        transform.rotation = m_player.transform.rotation;
	}
}
