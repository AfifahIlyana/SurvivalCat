using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour {

    public GameObject optionPanel;

    private bool isShown = false;

    public void ShowOptions() {

        if (isShown == false) {
            isShown = true;
            optionPanel.SetActive(true);

        } else {
            isShown = false;
            optionPanel.SetActive(false);

        }
    }

}
