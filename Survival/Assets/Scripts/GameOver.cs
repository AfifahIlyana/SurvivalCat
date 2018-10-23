using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject gameOverScreen; // add the game over screen UI 

    public void TriggerGameOver() {
        
        gameOverScreen.SetActive(true);

        // Add some sound effect here

    }

}
