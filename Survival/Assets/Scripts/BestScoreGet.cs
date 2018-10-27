using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreGet : MonoBehaviour {

    private Text bestScoreText;

    private void Start() {

        bestScoreText = GetComponent<Text>();

        bestScoreText.text = PlayerPrefs.GetInt("Best").ToString();


    }

}
