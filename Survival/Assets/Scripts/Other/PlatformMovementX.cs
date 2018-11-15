using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementX : MonoBehaviour 
{
    private Rigidbody m_rigidBody;
    private Collider m_baseCollider;

    private GameObject m_player;
    private GameObject m_enemy;

    private float m_rightLimit;
    private float m_leftLimit;
    private float m_direction;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_baseCollider = GetComponentInChildren<Collider>();

    }

    private void Start() 
    {
        m_enemy = GameObject.FindWithTag("Enemy");
        m_player = GameObject.FindWithTag("Player");
        m_baseCollider.gameObject.SetActive(false);

        m_rightLimit = 3f;
        m_leftLimit = -3f;

        // Randomly chooses the direction of the platfrom (-1, 0, 1)
        m_direction = Random.Range(-1, 2);

        // if -1 the platform move to the left
        // if 0 the platform will not move
        // if 1 the platform will move to the right
 
    }

    private void Update() 
    {
        if (m_player != null) {
            if (transform.position.y + 0.6f + 2.4f <= (m_player.transform.position.y)) {
                m_baseCollider.gameObject.SetActive(true);
            }
        } else if(m_enemy) {
            Debug.LogWarning("Player not found");

        }

        if (transform.localPosition.x >= m_rightLimit) 
        {
            MoveLeft();
            
        }

        if (transform.localPosition.x <= m_leftLimit) 
        {
            MoveRight();

        }

        Vector3 movement = Vector3.right * m_direction * Time.deltaTime;
        transform.Translate(movement, Space.Self);

    }

    private void MoveRight() {
        m_direction = 1;

    }

    private void MoveLeft() {
        m_direction = -1;
    }
}
