using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour 
{
    public int maxHp = 10;
    private int hp;

    void SetKinematic(bool newValue)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = newValue;
            rb.useGravity = newValue;
        }
    }

    void SetConstrains()
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
        }
    }

    void Start()
    {
        //SetKinematic(true);
        //hp = maxHp;
        SetConstrains();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            SetKinematic(false);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("in1");
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Debug.Log("in2");
    //        Vector3 direction = transform.position - collision.gameObject.transform.position;
    //        m_rigidBody.AddForceAtPosition(direction.normalized + new Vector3(50f, 50f, 50f), transform.position);
    //    }
    //}

    //public void Damage(DamageInfo info)
    //{
    //    if (hp <= 0) return;
    //    hp -= info.damage;
    //    if (hp <= 0) Die();
    //}
    //void Die()
    //{
    //    SetKinematic(false);
    //    GetComponent<Animator>().enabled = false;
    //    //Destroy(gameObject, 5);
    //}
}
