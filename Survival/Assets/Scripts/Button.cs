using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    private Animator animButton;

    private void Start() {
        animButton = GetComponent<Animator>();

    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player") {

            animButton.SetBool("ButtonDown", true);

            // Disable character control
            // Trigger tower rotation
            // Enable character control

        }
    }

    private void OnTriggerExit(Collider other) {
        animButton.SetBool("ButtonDown", false);
    }
    

}
