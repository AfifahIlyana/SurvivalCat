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

    private PlayerBehavior playerBehavior;

    private void Start() 
    {
        m_animButton = GetComponent<Animator>();
        playerBehavior = GameObject.FindGameObjectWithTag("PlayerBehavior").GetComponent<PlayerBehavior>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            if (!m_isRotated) {
                GameObject player = other.gameObject;
                PlayerController playerController = player.GetComponent<PlayerController>();

                playerController.UpdateMoveValue(0);

                player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
                playerController.SwishSoundPlay();

                m_isRotated = true;
                other.GetComponent<PlayerMovement>().ActivateRotatePlayer((int)m_rotation);
                //StartCoroutine(WaitStable());

            }

        } else if (other.gameObject.tag == "Threshold") {
            m_isRotated = false;
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

    //IEnumerator WaitStable() {
   //     playerBehavior.canMove = false;
   //     yield return new WaitForSeconds(1.5f);
   ///     playerBehavior.canMove = true;
   // }

}
