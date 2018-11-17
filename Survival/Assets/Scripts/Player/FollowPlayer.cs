using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    
    private GameObject player;
    private Transform playerPosition;

    private void Start() {
       // Debug.Log("Test");
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.GetComponent<Transform>();
    }

    private void Update() {
        transform.position = playerPosition.position;
        transform.rotation = playerPosition.rotation;
    }
}
