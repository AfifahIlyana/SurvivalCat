using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    //private Transform playerPosition;
    private PlayerController playerController;
    private PlayerAttack playerAttack;
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
        playerController.UpdateMoveValue(horizontal);
    }

    public void PlayerJumping()
    {
        playerController.Jump();
    }

    public void PlayerActions()
    {
       
                                              
        if(player.name.Contains("Cat"))
        {
            playerController.CatShooting();
        }

        else if(player.name.Contains("Dog"))
        {
            playerController.DogShooting();
        }

        else if(player.name.Contains("Monkey"))
        {
            playerController.MonkeyAttacking();
        }
    }
}
