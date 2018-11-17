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

    private void Start()
    {
        m_playerAnimator = GetComponent<Animator>();
        objectPooler = ObjectPoolers.Instance;
    }

    public void Shoot()
    {
        objectPooler.SpawnFromPool("Bullet", bulletSpawn.position, bulletSpawn.rotation);
    }

    public void ShootForDog()
    {
        objectPooler.SpawnFromPool("Bullet", bulletSpawn.position, bulletSpawn.rotation);
        objectPooler.SpawnFromPool("Bullet", bulletSpawn2.position, bulletSpawn2.rotation);
        objectPooler.SpawnFromPool("Bullet", bulletSpawn3.position, bulletSpawn3.rotation);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Weapon.m_collider.enabled = true;
        }

        else
        {
            Weapon.m_collider.enabled = false;
        }
    }

}
