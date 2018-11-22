using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    ObjectPoolers objectPooler;
    Animator m_playerAnimator;

    public GameObject bulletPrefab;

    public Transform bulletSpawn;
    public Transform bulletSpawn2;
    public Transform bulletSpawn3;

    public AudioClip catShootingSound;
    public AudioClip dogShootingSound;
    public AudioClip monkeyAttackSound;

    private AudioSource m_audioSource;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_playerAnimator = GetComponent<Animator>();
        objectPooler = ObjectPoolers.Instance;
    }

    public void Shoot()
    {
        objectPooler.SpawnFromPool("Bullet", bulletSpawn.position, bulletSpawn.rotation);
        if (catShootingSound != null)
        {
            //AudioSource.PlayClipAtPoint(catShootingSound, bulletSpawn.position);
            m_audioSource.clip = catShootingSound;
            m_audioSource.Play();
        }
    }

    public void ShootForDog()
    {
        objectPooler.SpawnFromPool("Bullet", bulletSpawn.position, bulletSpawn.rotation);
        objectPooler.SpawnFromPool("Bullet", bulletSpawn2.position, bulletSpawn2.rotation);
        objectPooler.SpawnFromPool("Bullet", bulletSpawn3.position, bulletSpawn3.rotation);
        //AudioSource.PlayClipAtPoint(dogShootingSound, bulletSpawn.position);

        m_audioSource.clip = dogShootingSound;
        m_audioSource.Play();

    }

    public void ShootForDogKeyboard()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            objectPooler.SpawnFromPool("Bullet", bulletSpawn.position, bulletSpawn.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn2.position, bulletSpawn2.rotation);
            objectPooler.SpawnFromPool("Bullet", bulletSpawn3.position, bulletSpawn3.rotation);

            m_playerAnimator.SetBool("isShooting", true);
            //m_playerAnimator.SetBool("isShooting", false);
        }
    }
    

}
