using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentScore : MonoBehaviour {

    // Under Player's component

    // TextMeshPro currentScore
    public TextMeshProUGUI currentScoreText;
    // TextMeshPro plus10 to instantiate
    public GameObject plus10;
    // TextMeshPro plus30 to instantiate
    public GameObject plus30;
    
    private int lastHeight;
    private int addScore;

    private void Start() {
        lastHeight = 0;
        addScore = 0;

    }

    private void Update() {
        HeightScore();

    }

    // Increase score if the player reaches new best height (y axis)
    private void HeightScore() {
        int yRounded = Mathf.RoundToInt(gameObject.transform.position.y);

        if (yRounded > lastHeight) {
            lastHeight++;
            
            addScore = int.Parse(currentScoreText.text) + 1;
            currentScoreText.text = addScore.ToString();

        }
    }

    private void DiamondScore() {
        addScore = int.Parse(currentScoreText.text) + 10;
        currentScoreText.text = addScore.ToString();

        AppearAndDestroy("Normal");

    }

    private void DiamondSpecialScore() {
        addScore = int.Parse(currentScoreText.text) + 30;
        currentScoreText.text = addScore.ToString();

        AppearAndDestroy("Special");

    }

    private void AppearAndDestroy(string type) {
        GameObject plusScoreText;

        switch (type) {
            case "Normal":
                plusScoreText = Instantiate(plus10, currentScoreText.transform.position, Quaternion.identity);
                plusScoreText.transform.SetParent(currentScoreText.gameObject.transform);

                plusScoreText.transform.localPosition = new Vector3(65f, -50f, 0f);

                Destroy(plusScoreText, 0.5f);
                break;

            case "Special":
                plusScoreText = Instantiate(plus30, currentScoreText.transform.position, Quaternion.identity);
                plusScoreText.transform.SetParent(currentScoreText.gameObject.transform);

                plusScoreText.transform.localPosition = new Vector3(65f, -50f, 0f);

                Destroy(plusScoreText, 0.5f);
                break;

        }

    }
}
