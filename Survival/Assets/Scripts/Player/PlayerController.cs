using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerAttack))]
[RequireComponent(typeof(PlayerData))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour 
{
    [System.Serializable]
    private enum Type
    {
        buttons,
        keyboard,
        joystick
    }

    [SerializeField]
    private Type inputController = new Type();

    private Animator m_animator;
    private Rigidbody m_rigidBody;

    private PlayerMovement m_playerMovement;
    private PlayerData m_playerData;
    private PlayerAttack m_playerAttack;
    private PlayerHealth m_playerHealth;

    [SerializeField]
    private float m_jumpForce = 300f;
    private float m_move;

    [SerializeField]
    private Joystick joystick;

    MyUIManager myUImanager;

	void Awake () 
    {
        m_animator = GetComponent<Animator>();
        m_rigidBody = GetComponent<Rigidbody>();
        m_playerMovement = GetComponent<PlayerMovement>();
        m_playerData = GetComponent<PlayerData>();
        m_playerAttack = GetComponent<PlayerAttack>();
        m_playerHealth = GetComponent<PlayerHealth>();

        myUImanager.ToggleSoundfx();


    }

    void Start()
    {
        m_playerHealth.ResetHealth(m_playerData);
    }

    void OnEnable()
    {
     //updatemutestatus 
    // getplayerpref music/sound
    }

    void FixedUpdate()
    {
        
        switch(inputController)
        {
            case Type.buttons:
                m_playerMovement.Move(m_rigidBody, m_move, m_animator);
                break;

            case Type.keyboard:
                m_move = Utility.GetAxis().x;
                m_playerMovement.Move(m_rigidBody, m_move, m_animator);
                m_playerMovement.JumpKeyboard(m_move, m_jumpForce, m_rigidBody);
                m_playerAttack.ShootForDogKeyboard();
                break;
                 
            case Type.joystick:
                m_move = Utility.GetAxisJoystick(joystick).x;
                break;

        }

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
        m_playerMovement.Jump(m_move, m_jumpForce, m_rigidBody);
    }

    public void CatShooting()
    {
        m_animator.SetTrigger("isShooting");
        m_playerAttack.Shoot();
    }

    public void DogShooting()
    {
        m_animator.SetTrigger("isShooting");
        m_playerAttack.ShootForDog();
    }

    public void MonkeyAttacking()
    {
        m_animator.SetTrigger("isAttacking");
    }
}
