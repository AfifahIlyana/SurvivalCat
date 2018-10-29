using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerAttack))]
[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour 
{
    private Animator m_animator;
    private Rigidbody m_rigidBody;
    private PlayerMovement m_playerMovement;
    private PlayerData m_playerData;
    private PlayerHealth m_playerHealth;

    [SerializeField]
    private float m_jumpForce;
    private float m_move;

    [SerializeField]
    private Joystick joystick;

	void Start () 
    {
        m_animator = GetComponent<Animator>();
        m_rigidBody = GetComponent<Rigidbody>();
        m_playerMovement = GetComponent<PlayerMovement>();
        m_playerData = GetComponent<PlayerData>();
        m_playerHealth = GetComponent<PlayerHealth>();

        m_playerHealth.ResetHealth(m_playerData);
	}

    void FixedUpdate()
    {
        m_playerMovement.Move(m_rigidBody, m_move, m_animator);

        //m_move = Utility.GetAxis().x;
        //m_move = Utility.GetAxisJoystick(joystick).x;
        //
        //m_playerMovement.Jump(m_move, m_jumpForce, m_rigidBody);
        //m_playerMovement.JumpSwipe(m_move, m_jumpForce, m_rigidBody);
        //m_move = Utility.GetAxisJoystick(joystick).y;
    }


    void Update()
    {
        //m_playerMovement.RotatePlayer();
        m_playerMovement.ActivateRotatePlayer();
        m_playerMovement.RotateTest5();

    }

    public void UpdateMoveValue(float horizontal)
    {
        m_move = horizontal;
    }

    public void Jump()
    {
        Debug.Log("im in public jump");
        m_playerMovement.Jump(m_move, m_jumpForce, m_rigidBody);
    }
}
