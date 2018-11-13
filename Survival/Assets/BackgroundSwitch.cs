using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSwitch : MonoBehaviour {

    public GameObject nextBG_1;
    public GameObject nextBG_2;

    public GameObject previousBG_1;
    public GameObject previousBG_2;

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {

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

        }
    }
}
