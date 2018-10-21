using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithCamera : MonoBehaviour 
{

    public Transform m_player;
    public bool m_position;
    public bool m_rotation;

	void Start () 
    {
        if (m_position)
        {
            transform.position = m_player.transform.position;
        }
        if (m_rotation)
        {
            transform.rotation = m_player.transform.rotation;
        }
	}
	
	void Update () 
    {
        if (m_position)
        {
            transform.position = m_player.transform.position;
        }
        if (m_rotation)
        {
            transform.rotation = m_player.transform.rotation;
        }
	}
}
