using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public bool[] m_isRotating = {false, false};
    float m_initialRotation = 0;

    public float m_maxSpeed = 10f;
    private bool m_isFacingRight = true;
    private Animator anim;

    public void Move(Rigidbody rigidBody, float move, Animator animator)
    {
        animator.SetFloat("speed", Mathf.Abs(move));
        anim = GetComponent<Animator>();
        
        Vector3 moves = CheckRotationDirection(move);

        if (move != 0f) {

            anim.SetBool("isWalking", true);
            rigidBody.velocity = new Vector3(moves.x * m_maxSpeed, rigidBody.velocity.y, moves.z * m_maxSpeed);
            //rigidBody.velocity += Vector3.right * move;

            if (move < 0 && !m_isFacingRight) {
                Flip();
            } else if (move > 0 && m_isFacingRight) {
                Flip();
            }

        } else {
            anim.SetBool("isWalking", false);

        }

    }

    public void Jump(float move, float jumpForce, Rigidbody rigidBody)
    {
        if (Input.GetButtonDown("Jump"))
        {
            //anim.SetBool("ground", false);
            Vector3 moves = CheckRotationDirection(move);
            rigidBody.AddForce(new Vector3(moves.x * m_maxSpeed, jumpForce, moves.z * m_maxSpeed));
        }
    }

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

    public void RotatePlayerNow() {
        Rotate(1f, 1);
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
            //m_initialRotation += 90f * dir;
            //transform.rotation = Quaternion.AngleAxis(m_initialRotation + (dir *90f), Vector3.up);
            //transform.eulerAngles = new Vector3(transform.eulerAngles.x, m_initialRotation, transform.eulerAngles.z);
        }
    }

    private Vector3 CheckRotationDirection(float move)
    {
        if (transform.rotation.eulerAngles.y <= 45f && transform.rotation.eulerAngles.y >= -45f)
        {
            Debug.Log("Positive x");
            return new Vector3(move, 0f, 0f);
        }
        else if (transform.rotation.eulerAngles.y >= 45f && transform.rotation.eulerAngles.y <= 135)
        {
            Debug.Log("Negative x");
            return new Vector3(0f, 0f, -move);
        }
        else if(transform.rotation.eulerAngles.y >= 135f && transform.rotation.eulerAngles.y <= 275f)
        {
            Debug.Log("Positive z");
            return new Vector3(-move, 0f, 0f);
        }
        else if (transform.rotation.eulerAngles.y <= -45f && transform.rotation.eulerAngles.y >= -135f)
        {
            Debug.Log("Negative z");
            return new Vector3(0f, 0f, move);
        }
        return Vector3.zero;
    }

    void Flip()
    {
        m_isFacingRight = !m_isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //Rotation alternative
    //float currentAngle = transform.rotation.eulerAngles.y;
    //transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * -90f), Vector3.up);
    //
    //Quaternion target = Quaternion.Euler(0, 90 * dir, 0);
    //// Dampen towards the target rotation
    //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5f);
}
