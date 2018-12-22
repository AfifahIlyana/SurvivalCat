using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour {

    public GameObject optionPanel;
    public GameObject defaultPage;
    public GameObject aboutPage;

    private bool isShown = false;

    public void ShowOptions() {

        if (isShown == false) {
            isShown = true;
            optionPanel.SetActive(true);

        } else {
            isShown = false;
            optionPanel.SetActive(false);
            defaultPage.SetActive(true);
            aboutPage.SetActive(false);
        }
    }

}
