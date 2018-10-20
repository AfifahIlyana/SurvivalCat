using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour {

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {

            SendMessageUpwards("Rotates");

        }
    }

}
