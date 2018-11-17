using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
	}
	
	public void Shoot () {
        //Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        //ObjectPooler.Instance.SpawnFromPool("Bullet", transform.position, transform.rotation );
        animator.SetTrigger("isAttacking");
	}

    private void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

        if (collision.transform.tag == "Enemy")
        {
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            gameObject.SetActive(false);
        }

    }

}
