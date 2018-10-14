using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public bool[] m_isRotating = {false, false};
    float m_initialRotation = 0;

    public void RotatePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Q) || m_isRotating[1])
        {
            Rotate( 1f, 1);
        }
        else if (Input.GetKeyDown(KeyCode.E) || m_isRotating[0])
        {
            Rotate(-1f, 0);
        }
    }

    private void Rotate(float dir, int i)
    {
        if (!m_isRotating[i])
        {
            m_isRotating[i] = true;
            m_initialRotation = transform.rotation.eulerAngles.y;
        }

        transform.Rotate(Vector3.up, 90f * dir * Time.deltaTime, Space.World);

        if (Mathf.Abs(m_initialRotation - transform.rotation.eulerAngles.y) >= 90f)
        {
            m_isRotating[i] = false;
            m_initialRotation += 90f * dir;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, m_initialRotation, transform.eulerAngles.z);
        }
    }

    //Rotation alternative
    //float currentAngle = transform.rotation.eulerAngles.y;
    //transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * -90f), Vector3.up);
    //
    //Quaternion target = Quaternion.Euler(0, 90 * dir, 0);
    //// Dampen towards the target rotation
    //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5f);
}
