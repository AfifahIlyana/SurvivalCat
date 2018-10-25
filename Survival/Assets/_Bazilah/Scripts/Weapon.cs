using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private Animator animator;

    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    private void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        animator.SetTrigger("isShooting");
    }


}
 