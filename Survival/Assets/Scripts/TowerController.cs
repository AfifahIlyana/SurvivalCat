using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private GameObject m_player;

    [SerializeField]
    private float m_playerTresholdHeight = 20f;
    [SerializeField]
    private int m_moveTower = 30;

    private void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        MoveTower();
    }

    private void MoveTower()
    {
        float playerHeightRelativeToTower = m_player.transform.position.y - transform.position.y;

        if (playerHeightRelativeToTower >= m_playerTresholdHeight)
        {
            transform.position += Vector3.up * m_moveTower;

            Utility.objectMovedUp = gameObject.transform.name;
        }
    }
}
