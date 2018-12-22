using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    public bool cheatMode = false; //  true for unlimited jump
    public GameObject lastPlatform;

    private bool isGrounded = true;
    
    private void OnCollisionStay(Collision collision) {
        if (collision.gameObject.name == "Ground" || collision.gameObject.name == "Button" || collision.gameObject.name == "Base" || collision.gameObject.tag == "Enemy") {
            isGrounded = true;
            lastPlatform = collision.gameObject;

        }

    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.name == "Ground" || collision.gameObject.name == "Button" || collision.gameObject.name == "Base" || collision.gameObject.tag == "Enemy")

            if (!cheatMode)
                isGrounded = false;
            else
                isGrounded = true;
    }

    public bool IsGrounded() {
        return isGrounded;
    }

    public void SetGrounded(bool grounded) {
        isGrounded = grounded;
    }

}
