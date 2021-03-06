﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObjectTransformation : MonoBehaviour
{
    public Transform m_gameObject;
    public bool m_position = false;
    public bool m_rotation = false;
    public bool m_goingUpOnly = false;

    private float m_maxHeight;

    void Start()
    {
        m_maxHeight = 0;

        FollowGameObjectPosition();
        FollowGameObjectRotation();
    }

    void LateUpdate()
    {
        if (m_gameObject != null)
        {
            FollowGameObjectPosition();
            FollowGameObjectRotation();
        }
    }

    private void FollowGameObjectRotation()
    {
        if (m_gameObject == null)
        {
            Debug.LogWarning("GameObject has not being assigned to FollowGameObjectRotation");
            return;
        }

        if (m_rotation)
        {
            transform.rotation = m_gameObject.transform.rotation;
        }
    }

    private void FollowGameObjectPosition()
    {
        if (m_gameObject == null)
        {
            Debug.LogWarning("GameObject has not being assigned to FollowGameObjectRotation");
            return;
        }

        if (m_position)
        {
            if (m_goingUpOnly)
            {
                while (m_gameObject.transform.position.y > m_maxHeight)
                {
                    m_maxHeight += 0.1f;
                }
                transform.position = Vector3.up * m_maxHeight;
            }
            else
            {
                m_maxHeight = m_gameObject.transform.position.y;
                transform.position = m_gameObject.transform.position;
            }
        }
    }
}
