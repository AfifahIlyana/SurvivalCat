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

    public AudioClip jumpSound;
    public AudioClip enemyDown;
    public AudioClip hitSound;
    public AudioClip gameOverSound;
    public AudioClip monkeyAttack;
    public AudioClip swishSound;
  //  public AudioClip enemyhitSound;

    private AudioSource[] m_audioSource;

	void Awake () 
    {
        m_animator = GetComponent<Animator>();
        m_rigidBody = GetComponent<Rigidbody>();
        m_playerMovement = GetComponent<PlayerMovement>();
        m_playerData = GetComponent<PlayerData>();
        m_playerAttack = GetComponent<PlayerAttack>();
        m_playerHealth = GetComponent<PlayerHealth>();

        m_audioSource = GetComponents<AudioSource>();

    }

    void Start()
    {
        m_playerHealth.ResetHealth(m_playerData);
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
                if (Input.GetKeyDown("g")) {
                    MonkeyAttacking();
                }
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
        //AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        m_audioSource[0].clip = jumpSound;
        m_audioSource[0].Play();

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
        //AudioSource.PlayClipAtPoint(monkeyAttack, transform.position);
        m_audioSource[0].clip = monkeyAttack;
        m_audioSource[0].Play();

        m_animator.SetTrigger("isAttacking");
        Invoke("Attack", 1f);
    }

    private void Attack()
    {
        Weapon.m_collider.enabled = true;
        //AudioSource.PlayClipAtPoint(m_playerAttack.monkeyAttackSound, transform.position);

    }

    public void EnemyDownSound() {
        //AudioSource.PlayClipAtPoint(enemyDown, transform.position);
        m_audioSource[1].clip = enemyDown;
        m_audioSource[1].Play();
    }

    public void HitSoundPlay() {
        //AudioSource.PlayClipAtPoint(hitSound, transform.position);
        m_audioSource[2].clip = hitSound;
        m_audioSource[2].Play();
    }

    public void GameOverSoundPlay() {
        //AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
        m_audioSource[0].clip = gameOverSound;
        m_audioSource[0].Play();

    }

    public void SwishSoundPlay() {
        m_audioSource[1].clip = swishSound;
        m_audioSource[1].Play();

    }

    public void EnemyHitSound() {
        m_audioSource[1].clip = hitSound;
        m_audioSource[1].Play();
    }

}
