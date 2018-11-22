using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public GameObject pauseButton;
    public GameObject playerHealth;
    public GameObject score;
    public GameObject movementButton;
    public GameObject actionButton;

    public GameObject continueButton;
    public GameObject usualButton;

    public GameObject gameOverScreen; // add the game over screen UI 
    public SaveBestScore scoreSave;

    private Text scoreText;

    public void ContinueGame() {
        pauseButton.SetActive(true);
        playerHealth.SetActive(true);
        score.SetActive(true);
        movementButton.SetActive(true);
        actionButton.SetActive(true);

        continueButton.SetActive(false);
        usualButton.SetActive(true);

        Time.timeScale = 1;

    }

    public void TriggerGameOver() {

        PlayerController gameOverSound = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        gameOverSound.GameOverSoundPlay();

        Time.timeScale = 0;
        
        pauseButton.SetActive(false);
        playerHealth.SetActive(false);
        score.SetActive(false);
        movementButton.SetActive(false);
        actionButton.SetActive(false);

        gameOverScreen.SetActive(true);
        scoreSave.GetFinalScore(); // Save score if higher than the current best score

        int finalScore = int.Parse(scoreSave.score.text);
        scoreText = GameObject.FindGameObjectWithTag("FinalScore").GetComponent<Text>();
        scoreText.text = finalScore.ToString();

        scoreText = GameObject.FindGameObjectWithTag("BestScore").GetComponent<Text>();
        scoreText.text = PlayerPrefs.GetInt("Best").ToString();

        // Add some sound effect here

    }

}
