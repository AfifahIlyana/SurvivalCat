using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private bool isGrounded = true;

    private void OnCollisionEnter(Collision collision) {
        isGrounded = true;

    }

    private void OnCollisionExit(Collision collision) {
        isGrounded = false;

    }

    public bool IsGrounded() {
        return isGrounded;
    }

}
