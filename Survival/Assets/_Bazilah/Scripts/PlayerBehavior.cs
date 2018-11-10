using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    //private Transform playerPosition;
    private PlayerController playerController;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //playerPosition = player.GetComponent<Transform>();
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
       // transform.position = playerPosition.position;

    }

    public void PlayerMovement(float horizontal)
    {
        Debug.Log("inda mau");
        playerController.UpdateMoveValue(horizontal);
        Debug.Log("lagi tia inda mau");
    }
}
