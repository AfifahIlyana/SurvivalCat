using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public bool[] m_isRotating = {false, false};
    float m_initialRotation = 0;

    public float m_maxSpeed = 10f;
    private bool m_isFacingRight = true;

    public void Move(Rigidbody rigidBody, float move, Animator animator)
    {
        animator.SetFloat("speed", Mathf.Abs(move));

        if (move != 0f) 
        {

            animator.SetBool("isWalking", true);

            var localVelocity = transform.InverseTransformDirection(rigidBody.velocity);
            localVelocity.x = move * m_maxSpeed;
            rigidBody.velocity = transform.TransformDirection(localVelocity);

            if (move < 0 && !m_isFacingRight) 
            {
                Flip();
            } else if (move > 0 && m_isFacingRight) 
            {
                Flip();
            }

        } 
        else 
        {
            animator.SetBool("isWalking", false);

        }

    }

    public void Jump(float move, float jumpForce, Rigidbody rigidBody)
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigidBody.AddRelativeForce(new Vector3(move, jumpForce, 0));
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
