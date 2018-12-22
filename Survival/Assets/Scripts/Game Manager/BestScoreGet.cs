using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreGet : MonoBehaviour {

    private Text bestScoreText;

    private void Start() {

        bestScoreText = GetComponent<Text>();
        bestScoreText.text = PlayerPrefs.GetInt("Best").ToString();

        CheckPlayable();

    }

    private void CheckPlayable() {
        int score = PlayerPrefs.GetInt("Best");
        Debug.Log(score);
        if (score >= 1000 && score < 5000) {
            PlayerPrefs.SetInt("Playable", 1);
            Debug.Log("checkign");
        } else if (score >= 5000) {
            PlayerPrefs.SetInt("Playable", 2);

        }

    }

}
