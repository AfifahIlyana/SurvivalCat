using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOB_GameOver : MonoBehaviour {
    
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            GameOver gameOver = GameObject.Find("Canvas").GetComponent<GameOver>();
            gameOver.TriggerGameOver();

        }
    }

}
