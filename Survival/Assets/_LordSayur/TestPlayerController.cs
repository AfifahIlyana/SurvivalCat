using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour 
{

    Rigidbody m_rigidBody;
    Vector3 m_move;
    float m_speed = 5f;
    private float m_rotate = 0;
    private float m_initialRotation = 0;
    private bool m_isRotating = false;

    void Start () 
    {
        m_rigidBody = GetComponent<Rigidbody>();
	}
	
	void Update () 
    {
        m_move = Utility.GetAxis() * m_speed * Time.deltaTime;

        m_rigidBody.transform.Translate(m_move);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            m_isRotating = true;
            m_initialRotation = transform.rotation.eulerAngles.y;
        }

        if (m_isRotating)
        {
            transform.localRotation = Quaternion.Euler(Vector3.up * m_rotate);

            m_rotate++;

            Debug.Log(Mathf.Abs(m_rotate - transform.rotation.eulerAngles.y));
            Debug.Log("rot" + transform.rotation.eulerAngles);

            if (Mathf.Abs(m_initialRotation - transform.rotation.eulerAngles.y) >= 90f)
            {
                m_isRotating = false;
            }
        }
    }
}
