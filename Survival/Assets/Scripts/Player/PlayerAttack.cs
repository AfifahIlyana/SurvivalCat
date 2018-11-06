using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    ObjectPoolers objectPooler;

    public GameObject bulletPrefab;

    public Transform bulletSpawn;

    private void Start()
    {
     
       objectPooler = ObjectPoolers.Instance;
    }

    public void Shoot()
    {
        objectPooler.SpawnFromPool("Bullet", bulletSpawn.position, bulletSpawn.rotation);
    }

}
