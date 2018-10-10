using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {
    
    private float movementRange = 10f; // Distance covered from left to right
    private float speed; // Speed of the platform

    private Vector3 initialPos;

    private void Start() {
        initialPos = gameObject.transform.position;

    }

    private void FixedUpdate() {
        
    }

    private void MoveLeft() {


    }

    private void MoveRight() {

    }

}
