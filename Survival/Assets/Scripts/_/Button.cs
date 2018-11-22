using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    [System.Serializable]
    private enum Rotation { AntiClockwise, Clockwise };
    [SerializeField]
    private Rotation m_rotation;
    private bool m_isRotated = false;
    private Animator m_animButton;
    
    private void Start() 
    {
        m_animButton = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!m_isRotated)
            {
                GameObject player = other.gameObject;

                player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

                m_isRotated = true;
                other.GetComponent<PlayerMovement>().ActivateRotatePlayer((int)m_rotation);

            }
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        m_animButton.SetBool("ButtonDown", true);

        // Disable character control
        // Trigger tower rotation
        // Enable character control
    }

    private void OnTriggerExit(Collider other) 
    {
        m_animButton.SetBool("ButtonDown", false);

    }

    public void Rotates() 
    {
        m_isRotated = !m_isRotated;
        Debug.Log(m_isRotated);

    }
    

}
