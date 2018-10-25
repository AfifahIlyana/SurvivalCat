using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject gameOverScreen; // add the game over screen UI 
    public SaveBestScore scoreSave;

    public void TriggerGameOver() {
        
        gameOverScreen.SetActive(true);
        scoreSave.GetFinalScore(); // Save score if higher than the current best score

        // Add some sound effect here

    }

}
