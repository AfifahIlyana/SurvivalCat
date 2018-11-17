using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetBestScore : MonoBehaviour {

    private Text bestScoreText;

    private void Start() {
        bestScoreText = GetComponent<Text>();

        UpdateBestScore();

    }

    private void UpdateBestScore() {
        bestScoreText.text = PlayerPrefs.GetInt("Best").ToString();

    }

}
