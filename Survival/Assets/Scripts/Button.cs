using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    private bool rotated = false;
    private Animator animButton;

    public object onClick { get; internal set; }

    private void Start() {
        animButton = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerMovement>().RotatePlayerNow();
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "Player") {
            animButton.SetBool("ButtonDown", true);

            // Disable character control
            // Trigger tower rotation
            // Enable character control

            if (rotated == false) {
                rotated = true;
                other.GetComponent<PlayerMovement>().RotatePlayerNow();

            }
        }
    }

    private void OnTriggerExit(Collider other) {
        animButton.SetBool("ButtonDown", false);

    }

    public void Rotates() {
        rotated = !rotated;
        Debug.Log(rotated);

    }
    

}
