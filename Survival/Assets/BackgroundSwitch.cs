using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSwitch : MonoBehaviour {

    public GameObject nextBG_1;
    public GameObject nextBG_2;

    public GameObject previousBG_1;
    public GameObject previousBG_2;

    public GameObject spaceBG;

    private bool firstPassed = false;

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {
            if (!gameObject.name.Contains("Space_BG")) {

                if (nextBG_1 != null) {
                    nextBG_1.SetActive(true);

                    if (nextBG_2 != null) {
                        nextBG_2.SetActive(true);
                    }

                }

                if (previousBG_1 != null) {
                    Destroy(previousBG_1);

                    if (previousBG_2 != null) {
                        Destroy(previousBG_2);
                    }

                }

            } else {
                if (!firstPassed) {
                    firstPassed = true;

                } else {
                    // Vector2 groundOffset = new Vector2(gameObject * 2f, 0);
                    // transform.position = (Vector2)transform.position + groundOffset;

                }

            }

        }
    }
}
