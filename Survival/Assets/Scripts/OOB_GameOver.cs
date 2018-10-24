using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOB_GameOver : MonoBehaviour {

    public GameObject gameOverText;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            GameOver gameOver = other.GetComponent<GameOver>();
            gameOver.TriggerGameOver();

        }
    }

}
