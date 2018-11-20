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
            ReverseDirection();
        }
    }
    
    public void MoveTowardsPlayer (GameObject enemy, Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("e" + Vector3.Normalize(enemy.transform.localScale).x);
            Debug.Log("p" + Vector3.Normalize(player.gameObject.transform.localScale).x);
            Debug.Log("b" + (enemy.transform.localScale.x / enemy.transform.localScale.x == player.transform.localScale.x / player.transform.localScale.x));

            if (CheckPlayerEnemyDirection(enemy, player.gameObject))
            {
                Debug.Log("in");
                ReverseDirection();
            }
        }
    }

    private void ReverseDirection()
    {
        //turn around
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        direction.x *= -1;
    }

    private bool CheckPlayerEnemyDirection (GameObject enemy, GameObject player)
    {
        return enemy.transform.localScale.x/ enemy.transform.localScale.x == player.transform.localScale.x/ player.transform.localScale.x;
    }
}
