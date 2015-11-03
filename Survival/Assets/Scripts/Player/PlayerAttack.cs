using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    ObjectPoolers objectPooler;

    public Transform bulletSpawn;

    private void Start()
    {
     
       objectPooler = ObjectPoolers.Instance;
    }

    public void Shoot()
    {
        // Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        objectPooler.SpawnFromPool("Bullet", bulletSpawn.position, bulletSpawn.rotation);
    }

}
