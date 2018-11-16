using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    public static float currentSpeed = 1f;

    private Animator animator;

    Vector3 direction = new Vector3(-1, 0, 0);

    public void Move()
    {
        transform.Translate(direction * currentSpeed * Time.deltaTime);
    }

    public void CheckEdgesPlatform(Collider other)
    {
        if (other.gameObject.tag == "Edge")
        {
            //Debug.Log("The edge is triggered");

            //turn around
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            direction.x *= -1;
        }
    }
}
