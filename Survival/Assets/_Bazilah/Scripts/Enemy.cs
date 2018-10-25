using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    public float currentSpeed;
    public static int health = 100;

    private Health playerHealth;
    private Animator animator;

    Vector3 direction = new Vector3(-1, 0, 0);


    public void Start()
    {
        animator = GetComponent<Animator>();
    }


    public void Update()
    {
        transform.Translate(direction * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Edge")
        {
            Debug.Log("The edge is triggered");

            //turn around
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            direction.x *= -1;
        } 
    }

}
