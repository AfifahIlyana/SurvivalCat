using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public bool m_isRotating = false;
    float m_initialRotation = 0;

    public void RotatePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Q) || m_isRotating)
        {
            Rotate(1f);
        }
        else if (Input.GetKeyDown(KeyCode.E) || m_isRotating)
        {
            Rotate(-1f);
        }
    }

    public void Rotate(float dir)
    {
        if (!m_isRotating)
        {
            m_isRotating = true;
            m_initialRotation = transform.rotation.eulerAngles.y;
            Debug.Log("initial " + m_initialRotation);
        }

        float currentAngle = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * 90f * dir), Vector3.up);

        if ( Mathf.Abs(m_initialRotation - transform.rotation.eulerAngles.y) > 90f)
        {
            m_isRotating = false;
            m_initialRotation += 90f * dir;
            transform.rotation = Quaternion.AngleAxis(m_initialRotation, Vector3.up);
            Debug.Log("Final " + m_initialRotation);
        }
    }
}
