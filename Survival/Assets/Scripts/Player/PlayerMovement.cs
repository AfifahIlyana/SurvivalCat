using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public bool[] m_isRotating = {false, false};
    float m_initialRotation = 0;

    public float m_maxSpeed = 10f;
    private bool m_isFacingRight = true;
    private float m_rotate;
    Quaternion m_targetRotation;

    [SerializeField]
    private Transform m_front;
    [SerializeField]
    private Transform m_right;
    [SerializeField]
    private Transform m_left;

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

    public void ActivateRotatePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Q) || m_isRotating[1])
        {
            //m_isRotating[1] = true;
            m_targetRotation = transform.rotation;
            m_targetRotation *= Quaternion.AngleAxis(90, Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.E) || m_isRotating[0])
        {
            //m_isRotating[0] = true;
            m_targetRotation = transform.rotation;
            m_targetRotation *= Quaternion.AngleAxis(-90, Vector3.up);
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

        //RotateTest1(dir);

        //RotateTest2(dir);

        //RotateTest3();

        RotateTest4(dir);


        if (Mathf.Abs(m_initialRotation - transform.rotation.eulerAngles.y) >= 90f)
        {
            m_isRotating[i] = false;
        }
    }

    private void RotateTest1(float dir)
    {
        transform.Rotate(Vector3.up, 90f * dir * Time.fixedDeltaTime, Space.World);
    }

    private void RotateTest2(float dir)
    {
        //Vector3 relativePos = (target.position + new Vector3(0, 1.5f, 0)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(Vector3.left * dir);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
    }

    private void RotateTest3()
    {
        transform.localRotation = Quaternion.Euler(Vector3.up * m_rotate);

        m_rotate++;
    }

    private void RotateTest4(float dir)
    {
        transform.rotation = Quaternion.Lerp(m_front.transform.rotation, m_right.transform.rotation , m_rotate * Time.deltaTime);
        m_rotate++;
    }

    public void RotateTest5()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, m_targetRotation, 5f * Time.deltaTime);
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
