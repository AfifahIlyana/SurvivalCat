using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveBestScore : MonoBehaviour {

    public TextMeshProUGUI score;

    private int finalScore;

    // call when gameover
    public void GetFinalScore() {
        finalScore = int.Parse(score.text);

        if (CompareBestScore()) {
            PlayerPrefs.SetInt("Best", finalScore);
        }
        
    }

    private bool CompareBestScore() {

        if (finalScore > PlayerPrefs.GetInt("Best")) {
            return true;

        } else {
            return false;

        }

    }
    
}
