using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePosition : MonoBehaviour {

    private Rect plusScore;

    public void Start() {
        plusScore = gameObject.GetComponent<Rect>();
    }

    public void ResetPosition() {
        plusScore.position = new Vector2(0f, 0f);
        Debug.Log("ResetPosition plus score");

    }

    public void MoveBack() {
        plusScore.position = new Vector2(-100f, 200f);

    }

}
