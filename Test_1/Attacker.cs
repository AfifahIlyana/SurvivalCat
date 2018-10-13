using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range(-1f, 1.5f)] //for sliding 
    public float currentSpeed;  
    private GameObject currentTarget;

	// Use this for initialization
	void Start () {
        Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        myRigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime); //move the attackers
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void SetSpeed (float speed) {
        currentSpeed = speed;
    }


    // Called from the animator at time of actual blow
    public void StrikeCurrentTarget(float damage)
    {
        Debug.Log(name  + "caused damage: " + damage);
        //if (currentTarget)
        //{
        //    //Health health = currentTarget.GetComponent<Health>();
        //    //if (health)
        //    //
        //        //health.DealDamage(damage);
        //   // }
        //}
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
