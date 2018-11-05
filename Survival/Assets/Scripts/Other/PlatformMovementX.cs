using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementX : MonoBehaviour 
{
    private Rigidbody m_rigidBody;
    private Collider m_baseCollider;

    private GameObject m_player;
    private float m_rightLimit;
    private float m_leftLimit;
    private float m_direction;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_baseCollider = GetComponentInChildren<Collider>();
        m_player = GameObject.FindWithTag("Player");
    }

    private void Start() 
    {
        m_baseCollider.gameObject.SetActive(false);

        m_rightLimit = transform.position.x + 3;
        m_leftLimit = transform.position.x - 3;

        // Randomly chooses the direction of the platfrom (-1, 0, 1)
        m_direction = Random.Range(-1, 2);

        // if -1 the platform move to the left
        // if 0 the platform will not move
        // if 1 the platform will move to the right
 
    }

    private void Update() {
        if (m_player != null) {

            if (transform.position.y + 0.6f < (m_player.transform.position.y)) {
                m_baseCollider.gameObject.SetActive(true);
            }

        }

        if (transform.position.x < m_leftLimit) {
            MoveRight();
            
        } else if (transform.position.x > m_rightLimit) {
            MoveLeft();

        }

        Vector3 movement = Vector3.right * m_direction * Time.deltaTime;
        transform.Translate(movement);

    }

    private void MoveRight() {
        m_direction = 1;

    }

    private void MoveLeft() {
        m_direction = -1;
    }
}
