using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    ObjectPoolers objectPooler;

    public GameObject bulletPrefab;

    public Transform bulletSpawn;
    public Transform bulletSpawn2;
    public Transform bulletSpawn3;

    private void Start()
    {
     
       objectPooler = ObjectPoolers.Instance;
    }

    public void Shoot()
    {

        objectPooler.SpawnFromPool("Bullet", bulletSpawn.position, bulletSpawn.rotation);

    }

    public void ShootForDog()
    {
        objectPooler.SpawnFromPool("Bullet", bulletSpawn2.position, bulletSpawn2.rotation);
        objectPooler.SpawnFromPool("Bullet", bulletSpawn3.position, bulletSpawn3.rotation);
    }

}
