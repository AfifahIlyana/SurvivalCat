using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    //private Transform playerPosition;
    private PlayerController playerController;
    private PlayerAttack playerAttack;
    private GameObject player;

    private GroundCheck groundCheck;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        //playerPosition = player.GetComponent<Transform>();

        groundCheck = player.GetComponent<GroundCheck>();

    }

    private void Update()
    {
       // transform.position = playerPosition.position;

    }

    public void PlayerMovement(float horizontal)
    {
        playerController.UpdateMoveValue(horizontal);
       // Debug.Log("Horizontal:" + horizontal);


    }

    public void PlayerJumping()
    {
      //  Debug.Log(groundCheck.IsGrounded());

        if(groundCheck.IsGrounded() == true)
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
