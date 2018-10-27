using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerAttack))]
[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour 
{
    PlayerMovement m_playerMovement;
    Animator m_animator;
    Rigidbody m_rigidBody;

    float m_move;
    public float m_jumpForce;

	void Start () 
    {
        m_playerMovement = GetComponent<PlayerMovement>();
        m_rigidBody = GetComponent<Rigidbody>();
        m_animator = GetComponent<Animator>();
	}

    void FixedUpdate()
    {
        m_move = Utility.GetAxis().x;
        m_playerMovement.Move(m_rigidBody, m_move, m_animator);
        m_playerMovement.Jump(m_move, m_jumpForce, m_rigidBody);
    }

    void Update()
    {
        m_playerMovement.RotatePlayer();
    }
}
